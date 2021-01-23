            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick +=
                delegate(object s, EventArgs args)
                {
                    TimeSpan time = (DateTime.Now - App.StartTime);
                    this.timenow.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);
                };
            timer.Interval = new TimeSpan(0, 0, 1); // one second
            timer.Start();
