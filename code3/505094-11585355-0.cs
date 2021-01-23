    private static U mProcess;
    protected ServiceHost mServiceHost = null;
    public static int StatusCheckFrequency
    {
        get { return mProcess.StatusCheckFrequency; }
        set { mProcess.StatusCheckFrequency = value; }
    }
