    public static void PrintReport(string path)
    {
        WebBrowser wb = new WebBrowser();
        wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
        wb.Navigate(path);
    }
    
    public static void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser wb = (WebBrowser)sender;
        if (wb.ReadyState.Equals(WebBrowserReadyState.Complete))
            wb.ShowPrintDialog();
    }
