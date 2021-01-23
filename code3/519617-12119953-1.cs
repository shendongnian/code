        String _oldUrl;
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
             String url = NavigationContext.QueryString["url"];
             if(url!=_oldUrl)
             {
                  if (!String.IsNullOrEmpty(url))
                  {
                         browser.Navigate(new Uri(url));
                  }
                  _oldUrl = url;
             }
        }
