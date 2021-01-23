    DateTime start;
    TimeSpan time;
    start = DateTime.Now;
    //Do something here
    time = DateTime.Now - start;
    label1.Text = String.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0'));
