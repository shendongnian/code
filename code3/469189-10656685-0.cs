    void Wait(int Milliseconds)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        while(sw.ElapsedMillisecods < Millisecods)
        {
            Application.DoEvents();
        }
        sw.Stop();
    }
