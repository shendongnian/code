       public static bool hasNetworkConnection()
        {
            switch(NetworkInformation.GetInternetConnectionProfile().GetNetworkConnectivityLevel())
            {
                case NetworkConnectivityLevel.InternetAccess:
                    return true;
                default:
                    return false;
            }
        }
