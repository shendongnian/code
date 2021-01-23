    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = "<html><body><input type=\"checkbox\" id=\"chk\" value=\"some\">some thing</body></html>";
        }
        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            foreach (HtmlElement el in webBrowser1.Document.All)
            {
                if (el.GetAttribute("type") == "checkbox")
                {
                    el.AttachEventHandler("onclick", (send, args) => OnElementClicked(el, EventArgs.Empty));
                }
            }
         
        }
        private object OnElementClicked(HtmlElement el, EventArgs eventArgs)
        {
            if (el.GetAttribute("checked") == "True")
            {
                MessageBox.Show("checked");
            }
            return false;
        }
    }
