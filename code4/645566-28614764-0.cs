    void MyWebBrowserControl_Navigating(object sender, NavigatingEventArgs e)
    {
        if (e.Uri.AbsolutPath.ToLower().EndsWith(".pdf"))
        {
            var success = Windows.System.Launcher.LaunchUriAsync(e.Uri);
        }
    }
