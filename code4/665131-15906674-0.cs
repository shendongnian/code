            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                //Get header of subject
                foreach (HtmlElement elementintable in webBrowser1.Document.GetElementById("toc").All)
                {
                    if (elementintable.TagName == "A")
                    {
                        //insert key and string to each node
                        treeView1.Nodes.Add(elementintable.GetAttribute("href").Split('#')[1], elementintable.InnerText);
                    }
                }
            }
