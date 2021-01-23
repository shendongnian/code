    MainPage()
    {
       if (App.isFourthLaunch)
        {
           Loaded += OnFourthLaunch;
        }
    }
    
    public void OnFourthLaunch(object sender, RoutedEventArgs e)
    {
        Loaded -= OnFourthLaunch;
        if (App.IsFourthLaunch)
         {
           MessageBox.Show("To Enable Full screen mode, go to settings and select Full Screen Browsing.");
           IsolatedStorageSettings.ApplicationSettings["IsFourthLaunchDone"] = true;
           App.IsFourthLaunch = false;
    
         }
    
    }
