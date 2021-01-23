    <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
        <WebView x:Name="MyWebView" Source="http://www.stackoverflow.com" />
    </Grid>
    void MyWebView_LoadCompleted(object sender, NavigationEventArgs e)
    {
        var _Original = MyWebView.RenderSize;
        // ask the content its width
        var _WidthString = MyWebView.InvokeScript("eval",
            new[] { "document.body.scrollWidth.toString()" });
        int _Width;
        if (!int.TryParse(_WidthString, out _Width))
            throw new Exception(string.Format("failure/width:{0}", _WidthString));
        // ask the content its height
        var _HeightString = MyWebView.InvokeScript("eval",
            new[] { "document.body.scrollHeight.toString()" });
        int _Height;
        if (!int.TryParse(_HeightString, out _Height))
            throw new Exception(string.Format("failure/height:{0}", _HeightString));
        // resize the webview to the content
        MyWebView.Width = _Width;
        MyWebView.Height = _Height;
        // scale the webview back to original height (can't do both height & width)
        var _Transform = (MyWebView.RenderTransform as ScaleTransform)
            ?? (MyWebView.RenderTransform = new ScaleTransform()) as ScaleTransform;
        var _Scale = _Original.Height / _Height;
        _Transform.ScaleX = _Transform.ScaleY = _Scale;
    }
