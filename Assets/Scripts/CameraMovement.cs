using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool IsPaused;

    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _panningTime;

    void Start()
    {
        StartCoroutine(PanCamera());
    }

    private IEnumerator PanCamera()
    {
        float timePassed = 0f;
        while (Mathf.Abs(Vector3.Distance(_endPoint.position, _camera.transform.position)) > 0.01f)
        {
            if (IsPaused) yield return null;

            _camera.transform.position = Vector3.Lerp(_startPoint.position, _endPoint.position, timePassed / _panningTime);
            yield return null;
        }

        _camera.transform.position = _endPoint.position;
    }
}
