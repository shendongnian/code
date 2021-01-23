        class MyClass
        {
            private DispatcherTimer _dispatcherTimer; //now your dispatcherTimer is accessible everywhere in this class
            
            public MyClass()
            {
                _dispatcherTimer = new DispatcherTimer();
                _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                _dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            }
            void PlayClick(object sender, EventArgs e)
            {
                VideoControl.Play();
                _dispatcherTimer.Start();
            }
            void dispatcherTimer_Tick(object Sender, EventArgs e)
            {
                _dispatcherTimer.Stop();
                VideoControl.Pause();
            }
        }
