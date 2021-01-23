    public static bool IsInternet()
    {
        ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
        bool internet = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
        return internet;
    }
