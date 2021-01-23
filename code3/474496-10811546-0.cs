    private readonly Object _dataLock = new Object();
    private string _sharedData = String.Empty;
    void OnGUI()
    {
        string text = "";
        lock (_dataLock)
            text = _sharedData;
    }
    void StartClient()
    {
        // ... [snip]
        var data = Encoding.ASCII.GetString(recData);
        lock (_dataLock)
            _sharedData = data;
    }
