     private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                btnsearch.Enabled = true;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.Navigate("http://in.finance.yahoo.com/actives?e=bo");
            }
    
            private void btnsearch_Click(object sender, EventArgs e)
            {
                foreach (HtmlElement item in webBrowser1.Document.GetElementsByTagName("td"))
                {
                    if (item.GetAttribute("className").Equals("second name"))
                    {
                        if (item.InnerText.Contains( txtsearch.Text))
                        {
                            lstresult.Items.Add(item.InnerText);
                        }
                    }
                }
            }
