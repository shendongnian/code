    private void WebView1_NewWindowRequested(
        WebView sender,
        WebViewNewWindowRequestedEventArgs args)
    {
        Debug.WriteLine(args.Uri);
        args.Handled = true; // Prevent the browser from being launched.
    }
