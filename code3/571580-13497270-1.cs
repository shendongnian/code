    public MainWindow()
    {
        WebCore.Started += WebCoreOnStarted;
        InitializeComponent();
    }
    
    private void WebCoreOnStarted(object sender, CoreStartEventArgs coreStartEventArgs)
    {
        var interceptor = new CustomResourceInterceptor();
    
        WebCore.ResourceInterceptor = interceptor;
        //webView is a WebControl on my UI, but you should be able to create your own WebView off WebCore
        webView.Source = new Uri("http://www.google.com");
    }
