    protected virtual void DoProcess<T>(T internalData)
    {
        if (!(internalData is InternalData))
        {
            throw new ArgumentOutOfRangeException("internalData");
        }
    }
