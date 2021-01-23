    using Windows.Networking.Connectivity;      
      public static bool IsInternetConnected()
            {
                ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
                bool internet = connections != null && connections.GetNetworkConnectivityLevel() == `enter code here`NetworkConnectivityLevel.InternetAccess;
                return internet;
            }
