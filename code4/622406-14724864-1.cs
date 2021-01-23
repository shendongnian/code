    private DispatcherTimer d1, blueTimer;    // <-- d1 and blueTimer? blueTimer is never 
    //mentioned. However a "redTimer" object appears in your code
    
    private void but1_Click(object sender, RoutedEventArgs e) 
        {
            if (redTimer == null)   // <-- shouldn´t this be "(d1 == null)"?
            {
                d1 = new System.Windows.Threading.DispatcherTimer();
                d1.Tick += new EventHandler(d1_Tick);
                d1.Interval = new TimeSpan(0, 0, 1);
                d1.Start();
            }
        }
        private void but2_Click(object sender, RoutedEventArgs e)
        {
            if (d2 == null)
            {
                d2 = new System.Windows.Threading.DispatcherTimer();
                d2.Tick += new EventHandler(d2_Tick);
                d2.Interval = new TimeSpan(0, 0, 1);
                d2.Start();
            }
        }
