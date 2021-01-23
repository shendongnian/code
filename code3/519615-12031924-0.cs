        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            String url = NavigationContext.QueryString["url"];
            if (!String.IsNullOrEmpty(url))
            {
                browser.Navigate(new Uri(url));
            }
        }
