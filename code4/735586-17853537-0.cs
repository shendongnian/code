    private static void BindableSourcePropertyChanged(DependencyObject sender,
                                                DependencyPropertyChangedEventArgs e)
    {
        WebBrowser browser = sender as WebBrowser;
        if (browser != null)
        {
            BindableSourcePropertyChanged(new MyWebBrowser(browser), e);
        }
    }
    
    private static void BindableSourcePropertyChanged(MyWebBrowser browser,
                                                DependencyPropertyChangedEventArgs e)
    {
            browser.NavigateToString(e.NewValue.ToString());
    }
