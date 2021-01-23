        public bool checkInternetAccess()
        {
            var connectivityLevel = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile().GetNetworkConnectivityLevel();
            return connectivityLevel == NetworkConnectivityLevel.InternetAccess;
        }
