    var timer = new DispatcherTimer
                {
                     Interval = TimeSpan.FromSeconds(5)
                };
    timer.Tick += (o,e) =>
                this.button1.IsEnabled =
                     !Process.GetProcessesByName("TheExternalProgramName").Any();
    timer.Start();
