    public static BaseClient Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = (BaseClient)(new AdvancedClient(true));
                }
                return _instance;
            }
        }
    }
