            var timespan = new TimeSpan(12, 0, 0);
            var timer = new System.Timers.Timer(timespan.TotalMilliseconds);
            timer.Elapsed += (o, e) =>
            {
                // runs code here after 12 hours.
            };
            timer.Start();
