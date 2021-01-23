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
                    
                }
            }
        }
