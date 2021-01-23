    public static readonly object LockObj = new object();
    public void AnOperation()
    {
        lock (LockObj)
        {
            using (var fs = File.Open("yourfile.bin"))
            {
                // do something with file
            }
        }
    }
    public void SomeOperation()
    {
        lock (LockObj)
        {
            using (var fs = File.Open("yourfile.bin"))
            {
                // do something else with file
            }
        }
    }
