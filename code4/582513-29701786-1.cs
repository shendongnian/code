    class ConnectivityUtil
    {
        internal static bool HasInternetConnection()
        {            
            var connections = NetworkInformation.GetConnectionProfiles().ToList();
            connections.Add(NetworkInformation.GetInternetConnectionProfile());
            foreach (var connection in connections)
            {
                if (connection == null)
                    continue;
                if (connection.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                    return true;
            }
            return false;
        }
    }
