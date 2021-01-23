    public Form1()
            {
                InitializeComponent();
                webBrowser1.Navigate("To your register account url");
            }
            int on = 0;
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                foreach (HtmlElement btn in webBrowser1.Document.GetElementsByTagName("button"))
                {
                    if (btn.GetAttribute("className") == "yourclassname")
                    {
                        btn.InvokeMember("Click");
                        break;
                    }
                }
            }
