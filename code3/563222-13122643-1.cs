        public MainWindow  //Obviously more went here, but it's not relevant
        {  
           private static MainViewModel _mainViewModel = new MainViewModel();
           public MainWindow() 
           { 
              this.DataContext = _mainViewModel;
           }
           static public void ChangeStatusText(string status)
           { 
             _mainViewModel.StatusText = status;
           }
         }
