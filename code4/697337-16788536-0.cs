            public void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                WebBrowser browser = sender as WebBrowser;
                
                if(browser.Document != null)
                {
                    var links = browser.Document.GetElementsByTagName("a");
    
                    foreach (HtmlElement link in links)
                    {
                        if (link.GetAttribute("class") == "expand-chain no-tracks")
                        {
                            MessageBox.Show("Here");
                            link.InvokeMember("click");
                        }
                    }
                 }
            }
