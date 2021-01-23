    System.Windows.Threading.DispatcherTimer dispatcherTimer = sender as System.Windows.Threading.DispatcherTimer; 
 
            dispatcherTimer.Stop(); 
            MainWindow _new = new MainWindow(); 
            _new.Show(); 
            this.Close(); 
} 
