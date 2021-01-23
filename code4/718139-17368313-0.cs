    public bool Contains(string item)
    {
        lock(listLock)
        {
           return list.Contains(item);
        }
    }
