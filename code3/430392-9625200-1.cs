    public void ForceEvaluation()
    {
        if (_enumerator != null) {
            _enumerator = _enumerable.GetEnumerator();
        }
        while (_enumerator.MoveNext()) {
        }
    }
