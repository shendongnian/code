        private string tempUri;
        public override Uri MapUri(Uri uri)
        {
            tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());          
            if (tempUri.Contains("yourprotocol"))
            { 
             return new Uri("YourPage.xaml", UriKind.Relative);
            }
            else
                {
                    return new Uri("MainPage.xaml", UriKind.Relative);
                }           
        }
    } 
