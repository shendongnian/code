    public void Add(double item)
    {
        lock(_list.SyncRoot)
        {
            _list.Add(item);
        }
    }
