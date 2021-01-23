    private async void LaunchSite(string siteAddress)
    {
        try
        {
            Uri uri = new Uri(siteAddress);
            var launched = await Windows.System.Launcher.LaunchUriAsync(uri);
        }
        catch (Exception ex)
        {
            //handle the exception
        }
    }
