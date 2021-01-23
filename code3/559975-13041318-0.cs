    DateTime dt = DateTime.Now;
    Thread.Sleep(3000);
    TimeSpan ts = TimeSpan.FromTicks(DateTime.Now.Subtract(dt).Ticks * (100000 - 7) / 7);
    Debug.WriteLine(ts.ToString());
    Thread.Sleep(1000);
    ts = TimeSpan.FromTicks(DateTime.Now.Subtract(dt).Ticks * (100000 - 9) / 9);
    Debug.WriteLine(ts.ToString());
