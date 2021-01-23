    public virtual bool MoveNext()
    {
        if (this.version != this.hashtable.version)
        {
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
        }
    	..........
    }
