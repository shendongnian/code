    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.Navigate("www.google.ca");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser browser = webBrowser1;
            HtmlElementCollection imgCollection = browser.Document.GetElementsByTagName("img");
            WebClient webClient = new WebClient();
            foreach (HtmlElement img in imgCollection)
            {
                string url = img.GetAttribute("src");
                string name = System.IO.Path.GetFileName(url);
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, name);
                webClient.DownloadFile(url, path);
            }
        }
    }
