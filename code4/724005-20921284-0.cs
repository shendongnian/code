    public partial class frmBrowser : Form
    {
        HtmlDocument doc;
    
        [ComVisible(true)]
        public class ScriptManager
        {
            private frmBrowser mForm;
    
            public ScriptManager(frmBrowser form)
            {
                 mForm = form;
            }
    
            public void recall(string statusID)
            {
                 mForm.RestoreStatus(statusID);
            }
        }
    
        public frmBrowser()
        {
            InitializeComponent();
            this.webBrowser.ObjectForScripting = new ScriptManager(this);
            string url = "file:///" + Application.StartupPath + "\\start\\start.html";
            this.webBrowser.Navigate(url);
        }
    
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            doc = webBrowser.Document;
            showRecent();
        }
    
        private void showRecent()
        {
            HtmlElement divRecent = doc.GetElementById("recent_cont");
            List<DaoStatus> status = Center.DB.GetUIStatus();
            string html = "";
            foreach (DaoStatus st in status)
            {
                 html += "<button onclick=\"javascript:window.external.recall('" + st.ID + "');\">" + st.Name + "</button>";
            }
            divRecent.InnerHtml = html;
        }
    }
    
