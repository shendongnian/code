    private bool _isConnected;
    public static bool IsConnected
    {
        get
        {
            _isConnected = CheckInternetStatus();
            return _isConnected;
        }
        set
        {
            _isConnected = value;
        }
    }
