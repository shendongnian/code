    if (IsolatedStorageSettings.ApplicationSettings.Contains("LocationConsent"))
    {
        return;
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
 
