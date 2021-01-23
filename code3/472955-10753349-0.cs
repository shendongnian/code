    private Object outputLock = new Object();
    public void setOutput(int value)
    {
        if Monitor.TryEnter(outputLock)
        {
            try
            {
                .... your code in here
            }
            finally
            {
                Monitor.Exit(outputLock);
            }
        }
    }
