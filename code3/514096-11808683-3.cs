    public static void ProcessObject(int x)
    {
        ProcessObject(GetObject(x));
    }
    public static void ProcessObject(string x)
    {
        ProcessObject(GetObject(x));
    }
    private static void ProcessObject(object o)
    {
        // do stuff with o
    }
