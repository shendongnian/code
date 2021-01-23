    void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        var br = sender as WebBrowser;
        if (state == 0) {
           // You are now on the main page, set the searchInput and submit click
           //...
           state = 1;
        }
        else if (state == 1) {
           // You are now on the searched page, do whatever you need to do
           //...
           // And if you are done:
           Application.ExitThread();
        }
    }
