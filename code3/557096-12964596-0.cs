     bool loaded;
    void Operate()
    {
                string[] lines = TextBox1.Text.Split('\n');
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
    
                for (int i = 0; i < lines.Length; i++)
                {
                    loaded = false;
                    HtmlElement ele = webBrowser1.Document.GetElementById("element ID");
                    ele.InnerText = lines[i];
                    //click a button here
                    HtmlElement elmbutton = webBrowser1.Document.GetElementById("ButtonID");
                    elmbutton.InvokeMember("click");
                    //here wait for web browser navigate.
                    while (!loaded)
                    {
                        System.Threading.Thread.Sleep(10);
                       Application.DoEvents();
                    }
                }
    
            }
            
            void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                loaded = true;
            }
