    class RunDownloader
        {
            Timer _tickTimer;
            MainWindow window;
    
            public RunDownloader(MainWindow window)
            {
                this.window = window;
            }
    
            private delegate void MyDel(string str);
    
            public void StartTickTimer()
            {
                const double interval = 1000;
    
                if (_tickTimer == null)
                {
                    _tickTimer = new Timer
                    {
                        Interval = interval
                    };
                    _tickTimer.Elapsed += (object sender, ElapsedEventArgs e) =>
                        {
                            window.Dispatcher.BeginInvoke(new MyDel(window.ChangeTime), DateTime.Now.ToLongDateString());
                        };
                }
    
                _tickTimer.Start();
            }
    
        }
