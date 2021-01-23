    private bool _isConnected;
    public static bool IsConnected
    {
        get
        {
            _IsConnected = CheckInternetStatus();
            return _IsConnected;
        }
        set
        {
            _IsConnected = value;
        }
    }
