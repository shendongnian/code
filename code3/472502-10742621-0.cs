    private static Testing _Instance;
    public static Testing Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new Testing();
            return _Instance;
        }
    }
