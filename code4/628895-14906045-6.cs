    private static bool _isConnected;
    public static bool IsConnected {
        get {
            CheckInternetStatus();
            return _isConnected;
        }
        set {
            _isConnected= value;
        }
    }
