    public static bool IsConnectedToInternet()
    {
        ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();
        return (connectionProfile!=null && connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
     }
