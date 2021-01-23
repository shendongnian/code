    protected override void Render(HtmlTextWriter writer)
     {
       
            StringBuilder builder = new StringBuilder();
            HtmlTextWriter htw = new HtmlTextWriter(new StringWriter(builder));
            base.Render(htw);
            string html = builder.ToString();
            _Generate(html);
     } 
    private void _Generate(string html)
    {
        var browser = new WebBrowser { ScrollBarsEnabled = false };
        DisplayHtml(html, browser);
        browser.DocumentCompleted += WebBrowser_DocumentCompleted;
        while (browser.ReadyState != WebBrowserReadyState.Complete)
           Application.DoEvents();  
        browser.Dispose();
    }
    private void DisplayHtml(string html, WebBrowser browser)
    {
        browser.Navigate("about:blank");
        if (browser.Document != null)
        {
            browser.Document.Write(string.Empty);
        }
        browser.DocumentText = html;
    }
