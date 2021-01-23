    DateTime dt = DateTime.Now;
    Thread.Sleep(3000);
    TimeSpan ts = TimeSpan.FromTicks((long)((double)DateTime.Now.Subtract(dt).Ticks * (100000.0 - 7.0) / 7.0));
    Debug.WriteLine(ts.ToString());
    Thread.Sleep(1000);
    ts = TimeSpan.FromTicks((long)((double)DateTime.Now.Subtract(dt).Ticks * (100000.0 - 9.0) / 9.0));
    Debug.WriteLine(ts.ToString());
