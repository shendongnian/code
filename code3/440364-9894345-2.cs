    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
            webBrowser1.ObjectForScripting = new ScriptManager(this);
        }
        private void btnShowMessage_Click(object sender, EventArgs e) {
            object[] o = new object[1];
            o[0]=txtMessage.Text;
            object result = this.webBrowser1.Document.InvokeScript("ShowMessage", o);
        }
        private void frmMain_Load(object sender, EventArgs e) {
            this.webBrowser1.Navigate(@"E:\Projects\2010\WebBrowserJavaScriptExample\WebBrowserJavaScriptExample\TestPage.htm");
        }
        [ComVisible(true)]
        public class ScriptManager {
            frmMain _form;
            public ScriptManager(frmMain form) {
                _form = form;
            }
            public void ShowMessage(object obj) {
                MessageBox.Show(obj.ToString());
            }
        }
    }
