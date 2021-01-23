    pBar.Maximum = 10;
    int count = 0;
    Timer timer = new Timer();
    timer.Interval = 1000;
    timer.Tick += (source, e) =>
    {
        pBar.Value = count;
        if (pBar.Maximum == count)
        {
            pBar.Value = 0;
            timer.Stop();
        }
        count++;
    }
    timer.Start();
