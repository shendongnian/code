    private bool _Connected = false;
    public bool Connect()
    {
        // ...
        if (success)
        {
            _Connected = true;
        }
    }
    public bool Disconnect()
    {
        // ...
        _Connected = false;
    }
    public IEnumberable<Data> GetData()
    {
        if (!_Connected)
        {
            // Handle not connected here...
        }
    }
