    public void Start()
    {
        System.Windows.Forms.WebBrowser wb = new System.Windows.Forms.WebBrowser();
        wb.DocumentCompleted += WebBrowserDocumentCompleted;
        wb.Visible = true;
        wb.ScrollBarsEnabled = false;
        wb.ScriptErrorsSuppressed = true;
        wb.Navigate(url);
    }
    private void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if( (sender as WebBrowser).ReadyState == System.Windows.Forms.WebBrowserReadyState.Complete)
        {
            // Do what ever you want to do here when page is completely loaded.
        }
    }
