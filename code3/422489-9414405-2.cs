    if (!string.IsNullOrWhiteSpace(value))
    {
      System.Timers.Timer timer = new System.Timers.Timer(3000) { Enabled = true };
      timer.Elapsed += (sender, args) =>
        {
           this.InfoLabel(string.Empty);
           timer.Dispose();
        };
     }
