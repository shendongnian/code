    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
               
                if (webBrowser1.Url.AbsolutePath == "/login.php")
                {
                         // do login..      
                }
    
                if (FacebookOAuthResult.TryParse(e.Url, out result))
                {
                    if (result.IsSuccess)
                    {
                      FacebookClient fbClient = new FacebookClient(result.AccessToken);
                      dynamic friends = fbClient.Get("/me/friends"); //User friends
                      // do something.. 
                    }
                    else
                    {
                        string errorDescription = result.ErrorDescription;
                        string errorReason = result.ErrorReason;
                        string msg = String.Format("{0} ({1})", errorReason, errorDescription);
                        MessageBox.Show(msg, "User-authentication failed!");
                    }
                }
            }
