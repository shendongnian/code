    static Mutex m;
    static void Main()
    {
        m = GetMutex();
        Program.Run();
    }
