    private EventHandler onMyDataReceived;
    public event EventHandler OnMyDataReceived
    {
        add
        {
            lock (OnMyDataReceived)
            {
                onMyDataReceived += value;
            }
        }
        remove
        {
            lock (OnMyDataReceived)
            {
                onMyDataReceived -= value;
            }
        }
    }
