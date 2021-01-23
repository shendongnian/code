    private async void webView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if(null != args.Uri && args.Uri.OriginalString == "URL OF INTEREST")
            {
                args.Cancel = true;
                await Launcher.LaunchUriAsync(args.Uri);
            }
        }
