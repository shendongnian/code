        private void webBrowserControl_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string tagUpper = "";
            foreach (HtmlElement tag in (sender as WebBrowser).Document.All)
            {
                tagUpper = tag.TagName.ToUpper();
                if((tagUpper == "AREA") || (tagUpper == "A"))
                { 
                    tag.MouseUp += new HtmlElementEventHandler(this.link_MouseUp);
                }
            }
        }
