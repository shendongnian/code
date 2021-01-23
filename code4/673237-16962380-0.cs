    private void BrowserControl_Navigating(object sender, NavigatingEventArgs e)
            {            
                if (e.Uri.AbsolutePath.ToString() == "/connect/login_success.html")
                {
                    BrowserControl.Visibility = Visibility.Collapsed;
                }
                if (NavigatingCallback != null)
                {
                    NavigatingCallback();
                }
               
            }
