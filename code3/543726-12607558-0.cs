        class MyClass
        {
            private DispatcherTimer dispatcherTimer;
            
            public MyClass()
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            }
            public PlayMovie()
            {
                VideoControl.Play();
                dispatcherTimer.Start();
            }
            void dispatcherTimer_Tick(object Sender, EventArgs e)
            {
                dispatcherTimer.Stop();
                VideoControl.Stop();
            }
        }
