    public static Singletone Instance()
    {
        if (_instance == null)
        {
            lock (_instance)
            {
                if (_instance == null)
                {
                    _instance = new Singletone ();
                }
            }
        }
        return _instance;;
    }
