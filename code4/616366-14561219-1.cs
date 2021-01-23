    private void webBrowser_TryLogoutLoadCompleted(object sender, EventArgs e)
            {
                try
                {
                    var cookies = webBrowser.GetCookies();
    
                    foreach (Cookie cookie in cookies)
                    {
                        if (cookie.Domain.Contains("m.facebook.com"))
                        {
                            cookie.Discard = true;
                            cookie.Expired = true;
                        }
                    }
                // we've just cleaned up cookies
                   
                }
                finally
                {
                    webBrowser.LoadCompleted -= webBrowser_TryLogoutLoadCompleted;
                }
            }
