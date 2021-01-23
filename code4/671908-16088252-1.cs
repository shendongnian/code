public static async System.Threading.Tasks.Task<bool> HasInternet()
{
    var profile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
    var hasNetAccess = profile != null;
    if (!hasNetAccess)
        await new Windows.UI.Popups.MessageDialog(
            content: InfoHub.AppHubViewModel.Strings.NoInternetWarning,
            title: InfoHub.AppHubViewModel.Strings.NoInternetWarning).ShowAsync();
    return hasNetAccess;
}
async void YourControlEvent_Click(object sender, ItemClickEventArgs e)
{
    //if net access, do your stuff, otherwise ignore for now
    if (await IsInternet())
    {
        //do net calls here
    }
}
