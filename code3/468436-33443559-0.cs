    public System.Windows.Forms.HtmlDocument GetHtmlDocument(string html)
            {
                WebBrowser browser = new WebBrowser();
                browser.ScriptErrorsSuppressed = true;
                browser.DocumentText = html;
                browser.Document.OpenNew(true);
                browser.Document.Write(html);
                browser.Refresh();
                return browser.Document;
            }
