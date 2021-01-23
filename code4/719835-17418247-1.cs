    // Note: you probably want System.Windows.Forms.Timer, so that it
    // will automatically fire on the UI thread.
    Timer timer = new Timer { Interval = 1000; }
    int i = 0;
    timer.Tick += delegate
    {
        listBox1.Items.Add("Number cities in problem = " + i);
        i++;
        if (i == 10)
        {
            timer.Stop();
            timer.Dispose();
        }
    };
    timer.Start();
