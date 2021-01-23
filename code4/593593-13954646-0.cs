    namespace WindowsFormsApplication7
    {
        public partial class Form1 : Form
        {
            List<string> fileList;
            List<string> printedFileList;
            public Form1()
            {
                InitializeComponent();
                fileList = new List<string>();
                printedFileList = new List<string>(); ;
                fileList.Add("http://www.google.de/");
                fileList.Add("http://www.yahoo.de/");
                webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            }
            void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                if (!printedFileList.Contains(webBrowser1.Url.AbsoluteUri))
                    webBrowser1.Print();
                printedFileList.Add(webBrowser1.Url.AbsoluteUri);
            }
            private async void Form1_Load(object sender, EventArgs e)
            {
                foreach (string link in fileList)
                {
                    webBrowser1.Navigate(link);
                    await Printed(link);
                }
            }
            private Task Printed(string link)
            {
                return Task.Factory.StartNew(() =>
                {
                    while (!printedFileList.Contains(link))
                    { }
                });
            }
        }
    }
