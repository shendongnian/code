async Task RefreshFromWeb(...)
{
    if (!App.HasInternetAccess)
    {
        await new Windows.UI.Popups.MessageDialog(Strings.NoInternetWarning).ShowAsync();
        return;
    }
    //attempt access here
}
public static bool HasInternetAccess
{
    get
    {
        var profile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
        if (profile == null)
            return false;
        return profile.GetNetworkConnectivityLevel() == 
               Windows.Networking.Connectivity.NetworkConnectivityLevel.InternetAccess;
    }
}
