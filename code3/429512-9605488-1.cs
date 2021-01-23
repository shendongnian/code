    public partial class Default : System.Web.UI.Page
    {
        public string TrackingString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TrackingString = "<YourHtmlTag></YourHtmlTag>";
        }
    }
