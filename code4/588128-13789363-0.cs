    void CreateOriginalPoints()
    {
        _originalPoints = new Vector3[_collisionPoints.Length];
        for (int i = 0; i < _collisionPoints.Length; i++)
            _originalPoints[i] = _collisionPoints[i];
    }
