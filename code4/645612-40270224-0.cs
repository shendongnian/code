        public static void DelayExecute(double delay, Action actionToExecute)
        {
            if (actionToExecute != null)
            {
                var timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(delay)
                };
                timer.Tick += (delegate
                {
                    timer.Stop();
                    actionToExecute();
                });
                timer.Start();
            }
        }
