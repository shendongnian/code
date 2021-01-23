    private static object lockObject = new object();
    private static void write_history(int index
    {
        lock(lockObject)
        {
            // Access file here
        }
    }
