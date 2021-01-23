    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // this assumes that you've added an instance of WebBrowser and named it webBrowser to your form
            SHDocVw.WebBrowser_V1 axBrowser = (SHDocVw.WebBrowser_V1)webBrowser.ActiveXInstance;
            // listen for new windows
            axBrowser.NewWindow += axBrowser_NewWindow;
        }
        void axBrowser_NewWindow(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed)
        {
            // cancel the PopUp event
            Processed = true;
            // send the popup URL to the WebBrowser control
            webBrowser.Navigate(URL);
        }
    }
