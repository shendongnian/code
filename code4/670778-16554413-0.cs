    public partial class WebForm1 : System.Web.UI.Page
    {
        public string link;
        protected void Page_Load(object sender, EventArgs e)
        {
            string ver = "1.0.0";
            link = "<link rel=\"stylesheet\"  href=\"../App_Themes/Global/Site.css?v=" + ver + "\"/>";
        }
    }
