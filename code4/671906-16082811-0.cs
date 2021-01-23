    public static bool IsInternetAvailable;
    
    void NetworkInformation_NetworkStatusChanged(object sender)
    {
        if (NetworkInformation.GetInternetConnectionProfile() != null)
            App.IsInternetAvailable = true;
        else
            App.IsInternetAvailable = false;
    }
