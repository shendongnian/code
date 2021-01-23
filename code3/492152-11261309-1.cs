    private static Task<HeavyObject> heavyObjectInitializer;
    public static void Bootstrap()
    {
        heavyObjectInitializer = new Task<HeavyObject>(() =>
        {
            // creation of heavy object here
            return new HeavyObject();
        });
        // Start running the initialization right now on a 
        // background thread. We don't have to wait on this.
        heavyObjectInitializer.Start();
    }
    public static HeavyObject GetHeavyObject()
    {
        // Get the initialized object, or block untill this 
        // instance gets available.
        return heavyObjectInitializer.Result;  
    }
