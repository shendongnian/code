       public static bool getIsInternetAccessAvailable()
        {
            switch(NetworkInformation.GetInternetConnectionProfile().GetNetworkConnectivityLevel())
            {
                case NetworkConnectivityLevel.InternetAccess:
                    return true;
                default:
                    return false;
            }
        }
