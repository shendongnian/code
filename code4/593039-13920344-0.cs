    private static readonly object _lock = new object();
    public int getCurrentValue(int valueID)
    {
        try
        {
            Monitor.Enter(_lock);
            value = // read value from DB
            return value;
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }
    public void updateValues(int componentID)
    {
        try
        {
            Monitor.Enter(_lock);
            // update values in DB
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }
