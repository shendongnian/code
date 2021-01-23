    if (IsolatedStorageSettings.ApplicationSettings.Contains("LocationConsent"))
    {
        if ((bool)IsolatedStorageSettings.ApplicationSettings["LocationConsent"] == true)
        {
           locationSwitch.IsChecked = true;
        }
        else
        {
           locationSwitch.IsChecked = false;
        }
    }
    else
    {
        MessageBoxResult result = MessageBox.Show("Allow this app to access your location?", "Location", MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.OK)
        {
           IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = true;
        }
        else
        {
           IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = false;
        }
        IsolatedStorageSettings.ApplicationSettings.Save();
    }
    private void locationSwitch_Checked(object sender, RoutedEventArgs e)
    {
        if (IsolatedStorageSettings.ApplicationSettings.Contains("LocationConsent"))
        {
           IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = true;
           IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }
    private void locationSwitch_Unchecked(object sender, RoutedEventArgs e)
    {
       if (IsolatedStorageSettings.ApplicationSettings.Contains("LocationConsent"))
       {
          IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = false;
          IsolatedStorageSettings.ApplicationSettings.Save();
       }
    }
