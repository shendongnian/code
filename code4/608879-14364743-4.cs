    public static bool CheckInternetAccess()
    {
      var profile = NetworkInformation.GetInternetConnectionProfile();
      if (profile == null) return false;
      var connectivityLevel = profile.GetNetworkConnectivityLevel();
      return connectivityLevel.HasFlag(NetworkConnectivityLevel.InternetAccess);
    }
