    public void CancelEdit()
    {
       _current = _previous;
       _proposed = null;
    }
    public void EndEdit()
    {
       _previous = _proposed;
    }
    public void BeginEdit()
    {
        _proposed = _current;
    }
