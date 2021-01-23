            private void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                TxtHour.Text = DateTime.Now.ToString("HH:mm:ss");
            }
    private void MainWindow_OnLoad(object sender, RoutedEventArgs e)
            {
                System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
                TxtDate.Text = DateTime.Now.Date.ToShortDateString();
            }
