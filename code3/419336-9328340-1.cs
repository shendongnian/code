    timer.Tick += new EventHandler(timer_Tick);
    timer.Interval = (1000) * (3); // Timer will tick every 3 seconds
    timer.Enabled = true;
    timer.Start();
    label.Text = DateTime.Now.ToString(); // initial label text.
