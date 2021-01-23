    public partial class browser : PhoneApplicationPage {
            private BrowserViewModel _vm;
            public browser()
            {
                InitializeComponent();
                Loaded += (s, e) => {
                                _vm = new BrowserViewModel();
                                DataContext = _vm;
                          };
            }
    
            protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
                string targetUrl = null;
                NavigationContext.QueryString.TryGetValue("url", out targetUrl);
    
                if(targetUrl != null)
                    webBrowser1.Navigate(new Uri(targetUrl, UriKind.Absolute));
    
                base.OnNavigatedTo(e);
            }
    
            private void ApplicationBarIconButton_Click(object sender, EventArgs e)
            {
                _vm.AddUrl(webBrowser1.Source.AbsoluteUri);
            }
    
            private void ApplicationBarIconButton_Click_1(object sender, EventArgs e) {
                NavigationService.Navigate(new Uri("/views/MainPage.xaml", UriKind.Relative));
            }
    
            private void btnGo_Click(object sender, System.Windows.RoutedEventArgs e)
            {
                webBrowser1.Navigate(new Uri(tbUrl.Text.Trim(), UriKind.Absolute));
            }
        }
