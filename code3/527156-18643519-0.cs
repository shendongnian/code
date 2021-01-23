    private void m_WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            Uri url = e.Uri;
            FacebookOAuthResult result;
            dynamic fb = new FacebookClient();
            if (fb.TryParseOAuthCallbackUrl(url, out result))
            {
                if (result.IsSuccess)
                {
                    AccessToken = result.AccessToken;
                    Window window = Window.GetWindow(this);
                    window.Close();                    
                }
                else
                {
                    var errorDescription = result.ErrorDescription;
                    var errorReason = result.ErrorReason;
                }
            }
        }
