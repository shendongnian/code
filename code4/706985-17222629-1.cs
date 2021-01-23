    <Grid Background="Blue">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="995" />
            <ColumnDefinition Width="300" />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <WebView Grid.Column="0" x:Name="MyWebView" Source="http://www.stackoverflow.com" HorizontalAlignment="Right" />
        <Rectangle Grid.Column="1" x:Name="MyWebViewRectangle" Fill="Red" />
        <ScrollViewer Grid.Column="2" HorizontalScrollBarVisibility="Auto" VerticalScrollBarVisibility="Auto">
            <ItemsControl x:Name="MyPrintPages" VerticalAlignment="Top" HorizontalAlignment="Left">
                <Rectangle Height="150" Width="100" Fill="White" Margin="5" />
                <Rectangle Height="150" Width="100" Fill="White" Margin="5" />
                <Rectangle Height="150" Width="100" Fill="White" Margin="5" />
                <Rectangle Height="150" Width="100" Fill="White" Margin="5" />
                <Rectangle Height="150" Width="100" Fill="White" Margin="5" />
            </ItemsControl>
        </ScrollViewer>
    </Grid>
    public MainPage()
    {
        this.InitializeComponent();
        MyWebView.LoadCompleted += MyWebView_LoadCompleted;
    }
    void MyWebView_LoadCompleted(object sender, NavigationEventArgs e)
    {
        MyWebViewRectangle.Fill = GetWebViewBrush(MyWebView);
        MyPrintPages.ItemsSource = GetWebPages(MyWebView, new Windows.Foundation.Size(100d, 150d));
        MyWebView.Visibility = Windows.UI.Xaml.Visibility.Visible;
    }
    WebViewBrush GetWebViewBrush(WebView webView)
    {
        // resize width to content
        var _OriginalWidth = webView.Width;
        var _WidthString = webView.InvokeScript("eval",
            new[] { "document.body.scrollWidth.toString()" });
        int _ContentWidth;
        if (!int.TryParse(_WidthString, out _ContentWidth))
            throw new Exception(string.Format("failure/width:{0}", _WidthString));
        webView.Width = _ContentWidth;
        // resize height to content
        var _OriginalHeight = webView.Height;
        var _HeightString = webView.InvokeScript("eval",
            new[] { "document.body.scrollHeight.toString()" });
        int _ContentHeight;
        if (!int.TryParse(_HeightString, out _ContentHeight))
            throw new Exception(string.Format("failure/height:{0}", _HeightString));
        webView.Height = _ContentHeight;
        // create brush
        var _OriginalVisibilty = webView.Visibility;
        webView.Visibility = Windows.UI.Xaml.Visibility.Visible;
        var _Brush = new WebViewBrush
        {
            SourceName = webView.Name,
            Stretch = Stretch.Uniform
        };
        _Brush.Redraw();
        // reset, return
        webView.Width = _OriginalWidth;
        webView.Height = _OriginalHeight;
        webView.Visibility = _OriginalVisibilty;
        return _Brush;
    }
    IEnumerable<FrameworkElement> GetWebPages(WebView webView, Windows.Foundation.Size page)
    {
        // ask the content its width
        var _WidthString = webView.InvokeScript("eval",
            new[] { "document.body.scrollWidth.toString()" });
        int _ContentWidth;
        if (!int.TryParse(_WidthString, out _ContentWidth))
            throw new Exception(string.Format("failure/width:{0}", _WidthString));
        webView.Width = _ContentWidth;
        // ask the content its height
        var _HeightString = webView.InvokeScript("eval",
            new[] { "document.body.scrollHeight.toString()" });
        int _ContentHeight;
        if (!int.TryParse(_HeightString, out _ContentHeight))
            throw new Exception(string.Format("failure/height:{0}", _HeightString));
        webView.Height = _ContentHeight;
        // how many pages will there be?
        var _Scale = page.Width / _ContentWidth;
        var _ScaledHeight = (_ContentHeight * _Scale);
        var _PageCount = (double)_ScaledHeight / page.Height;
        _PageCount = _PageCount + ((_PageCount > (int)_PageCount) ? 1 : 0);
        // create the pages
        var _Pages = new List<Windows.UI.Xaml.Shapes.Rectangle>();
        for (int i = 0; i < (int)_PageCount; i++)
        {
            var _TranslateY = -page.Height * i;
            var _Page = new Windows.UI.Xaml.Shapes.Rectangle
            {
                Height = page.Height,
                Width = page.Width,
                Margin = new Thickness(5),
                Tag = new TranslateTransform { Y = _TranslateY },
            };
            _Page.Loaded += (s, e) =>
            {
                var _Rectangle = s as Windows.UI.Xaml.Shapes.Rectangle;
                var _Brush = GetWebViewBrush(webView);
                _Brush.Stretch = Stretch.UniformToFill;
                _Brush.AlignmentY = AlignmentY.Top;
                _Brush.Transform = _Rectangle.Tag as TranslateTransform;
                _Rectangle.Fill = _Brush;
            };
            _Pages.Add(_Page);
        }
        return _Pages;
    }
