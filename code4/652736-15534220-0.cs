    Timer timer = new System.Windows.Forms.Timer();
    timer.Interval = 500;
    timer.Elapsed += (s,a) => {
      MyFunction();
      timer.Stop();
    }
    timer.Start();
