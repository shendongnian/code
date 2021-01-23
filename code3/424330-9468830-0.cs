    private static Singleton1 _instance;
    public static Singleton1 Instance {
        get {
            if(_instance == null)
                _instance = new Singleton1();
            return _instance;
        }
    }
