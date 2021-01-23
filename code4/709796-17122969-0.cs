    TimeSpan ts = new TimeSpan(new DateTime(2013,06,15,04,00,00).Ticks- DateTime.Now.Ticks);
            long ticks = ts.Ticks;
            long divide=    (long)Math.Pow(10, 7);
            long span = ticks / divide;
            timer.Interval = (int)span*1000;
            timer.Tick += timer_Tick;
            timer.Start();
