    static object _syncRoot = new object();
    public int getCurrentValue(int valueID)
    {
        lock(_syncRoot)
        {
            value = // read value from DB
        }
    }
    public void updateValues(int componentID)
    {
        lock(_syncRoot)
        {
            // update values in DB
        }
    }
