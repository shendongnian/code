    private void ChangeDocument(string documentText, double timeout)
    {
        DateTime startTime = DateTime.Now;
        double elapsed = 0;
        if (webBrowser1.Document == null)
        {
            webBrowser1.Navigate("about:blank");
        }
        webBrowser1.Document.OpenNew(false);
        while ((webBrowser1.DocumentText != "") && (elapsed < timeout))
        {
            Thread.Sleep(50);
            elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
        }
        webBrowser1.Document.Write(documentText);
        startTime = DateTime.Now;
        elapsed = 0;
        while ((webBrowser1.DocumentText != documentText) && (elapsed < timeout))
        {
            System.Threading.Thread.Sleep(50);
            elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
        }
    }
