    public void Free(IType obj)
    {
        if (obj is MyObject1)
        {
            if (pool1.Count < MAX_POOL_SIZE)
                pool1.Push(obj);
        }
        else if (obj is MyObject2)
        {
            if (pool2.Count < MAX_POOL_SIZE)
                pool2.Push(obj);
        }
        else if (obj is MyObject2)
        {
            if (pool3.Count < MAX_POOL_SIZE)
                pool3.Push(obj);
        }
    }
