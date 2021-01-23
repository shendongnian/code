    DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public App()
        {
            this.Deactivated += App_Deactivated;
            this.Activated += App_Activated;
            timer.Tick += delegate
            {
                Application.Current.MainWindow.Activate();
            };
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
        }
        void App_Activated(object sender, EventArgs e)
        {
            timer.Stop();
        }
       
        void App_Deactivated(object sender, EventArgs e)
        {
            timer.Start();
        }
