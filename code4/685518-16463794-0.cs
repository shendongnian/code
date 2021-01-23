     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            }
          
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.DocumentText = "<html><body><span class=\"cls\" id=\"el\"> </body></html>";
            }
    
            void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                //for element with id
                webBrowser1.Document.GetElementById("el").ScrollIntoView(true);
                //for element with spesific
                foreach (HtmlElement el in webBrowser1.Document.All)
                {
                    if (el.GetAttribute("ClassName") == "cls")
                    {
                        el.ScrollIntoView(true);
                    }
    
                }
             
            }
    
           
        }
