     private void browseGoogle_Loaded(object sender, RoutedEventArgs e)
        { 
            try
            {
                StringBuilder autheticateURL = new StringBuilder();
                autheticateURL.Append(GmailSettings.AuthorizeUri).Append("?client_id=").Append(GmailSettings.clientID).Append("&scope=").
                    Append(GmailSettings.ScopeValue).Append("&response_type=code").Append("&redirect_uri=").Append(GmailSettings.CallbackUri);
                browseGoogle.Navigate(new Uri(autheticateURL.ToString(), UriKind.Absolute));
            }
            catch (Exception ex)
            {
                Logger.log(TAG, "browseGoogle_Loaded()", ex.Message);
            }
        }
        /// <summary>
        /// Called when the web browser initiates Navigation to various pages 
        /// </summary>
        /// <param name="sender">Browser</param>
        /// <param name="e">Navigating event arguments</param>
        private void browseGoogle_Navigating(object sender, NavigatingEventArgs e)
        {
            try
            {
                string hostName = e.Uri.Host;
                string URL = e.Uri.ToString();
                if (hostName.StartsWith("localhost"))
                {
                    NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
                }
            }
            catch (Exception ex)
            {
                Logger.log(TAG, "browseGoogle_Navigating()", ex.Message);
            }
        }
