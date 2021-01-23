    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void _goButton_Click(object sender, EventArgs e)
        {
            _webBrowser.Navigate("http://google.com/");
            // Non-blocking call - method will return immediately
            // and page will load in background
        }
        private void _webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Navigation complete, we can now process the document
            string html = _webBrowser.Document.Body.InnerHtml;
            // If the processing is time-consuming, then you could spin
            // off a BackgroundWorker here
        }
    }
