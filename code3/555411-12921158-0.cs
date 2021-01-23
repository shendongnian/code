    static void Main()
    {
        ThreadTest tt = new ThreadTest();
        new Thread(tt.Incr).Start();
        tt.I(); // This will be executed first
        tt.I2(); // This will be executed last
    }
