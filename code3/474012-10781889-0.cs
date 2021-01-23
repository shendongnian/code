    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            webBrowser1.Url = new Uri("http://stackoverflow.com/questions/10781011/get-source-of-webpage-in-webbrowser-c-sharp");
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        void timer1_Tick(object sender, EventArgs e) {
            var elem = webBrowser1.Document.GetElementById("wmd-input");
            label1.Text = elem.InnerText;
        }
        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            timer1.Enabled = true;
        }
    }
