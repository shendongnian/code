    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            webBrowser1.LoadCompleted += new LoadCompletedEventHandler(webBrowser1_LoadCompleted);
        }
        private void webBrowser1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            mshtml.HTMLDocument doc;
            doc = (mshtml.HTMLDocument)webBrowser1.Document;
            mshtml.HTMLDocumentEvents2_Event iEvent;
            iEvent = (mshtml.HTMLDocumentEvents2_Event)doc;
            iEvent.onclick += new mshtml.HTMLDocumentEvents2_onclickEventHandler(ClickEventHandler);
        }
        private bool ClickEventHandler(mshtml.IHTMLEventObj e)
        {
            textBox1.Text = "Item Clicked";
            return true;
        }
    }
