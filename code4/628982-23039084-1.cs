    using Windows.Networking.Connectivity;      
    
    public static bool IsInternetConnected()
    {
        ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
        bool internet = (connections != null) && 
            (connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
                return internet;
    }
