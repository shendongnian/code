    public static Media Instance { get; private set; }
    // constructor
    public Media()
    {
        ...
        Instance = this;
    }
