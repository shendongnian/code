        public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            webBrowser1.Navigate("about:blank");
            dynamic ax = this.webBrowser1.ActiveXInstance;
            ax.NewWindow += new NewWindowDelegate(this.OnNewWindow);
            this.webBrowser1.Navigate("http://google.com");
        }
        private delegate void NewWindowDelegate(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed);
        private void OnNewWindow(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed)
        {
            Processed = true;
            //your own logic
        }
    }
