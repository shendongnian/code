        public MainForm()
        {
            InitializeComponent();
            var br = new WebBrowser();
            br.DocumentCompleted += webBrowser1_DocumentCompleted;
            br.Navigate("http://www.microsoft.com");
            MessageBox.Show("navigate called");//this fires immediately
        }
        static void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var wb = (WebBrowser)sender;
            //Console.WriteLine(wb.DocumentText);
            MessageBox.Show(wb.Text);
        }
