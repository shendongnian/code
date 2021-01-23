    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public string KeywordBox1
        {
            get { return txt_keyword.Text; }
            set { txt_keyword.Text = value; }
        }
    }
    public class SearchInitializer : WebForm1
    {
        public SearchInitializer()
        {
        }
        public void ChewSettings()
        {
            // Works
            base.KeywordBox1 = "Red";
        }
    }
