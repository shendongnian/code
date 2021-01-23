     public Form1()
            {
                InitializeComponent();
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.DocumentText = "<a href=\"www.aaa.xx/xx.zz?id=xxxx&name=xxxx\" ....></a><a href=\"http://www.aaa.xx/xx.zz?id=xxxx&name=xxxx\" ....></a><a href=\"https://www.aaa.xx/xx.zz?id=xxxx&name=xxxx\" ....></a><a href=\"www.aaa.xx/xx.zz/xxx\" ....></a>";
            }
    
            void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                List<string> href = new List<string>();
                foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("a"))
                {
                    href.Add(el.GetAttribute("href"));
                }
            }
