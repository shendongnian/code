    public void Add(double item)
    {
        lock(_list)
        {
            _list.Add(item);
        }
    }
