    int count; 
    count = 0; 
 
    public Windowsplash 
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        dispatcherTimer.Interval = new TimeSpan(0,0,0,500); 
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick); 
        dispatcherTimer.Start(); 
 
    private void dispatcherTimer_Tick(object sender, EventArgs e) 
    { 
        System.Windows.Threading.DispatcherTimer dispatcherTimer = sender as System.Windows.Threading.DispatcherTimer; 
 
            dispatcherTimer.Stop(); 
            MainWindow _new = new MainWindow(); 
            _new.Show(); 
            this.Close(); 
    } 
