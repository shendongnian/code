     private void Button1_Click_1(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();
                                 
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
               
            Random rnd = new Random();            
            Button1.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(
                          Convert.ToByte(rnd.Next(255)),
                          Convert.ToByte(rnd.Next(255)),
                          Convert.ToByte(rnd.Next(255)),
                          Convert.ToByte(rnd.Next(255))
                          ));             
        }
