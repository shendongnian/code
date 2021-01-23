     DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(50);
            tmr.Start();
            tmr.Tick += (sndr, ex) =>
                {
                    //send request 
                };
