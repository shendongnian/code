     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.DocumentText = "<html><body><textarea id=\"paste_content\" name=\"paste_content\"></textarea></body></html>";
            }
    
            void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                webBrowser1.Document.GetElementById("paste_content").InnerText = "test";
            }
        }
