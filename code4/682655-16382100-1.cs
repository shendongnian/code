    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                HtmlDocument doc = webBrowser1.Document;
                HtmlElement HTMLControl = doc.GetElementById("question-header");
                //HTMLControl.Style = "'display: none;'";
                if (HTMLControl != null)
                {
                    HTMLControl.Style = "display: none";
                }
            }
