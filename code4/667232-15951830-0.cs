    var t = new Timer();
    t.Interval = 3000; // it will Tick in 3 seconds
    t.Tick += (s, e) =>
    {
        lblWarning.Hide();
        t.Stop();
    }
    t.Start();
