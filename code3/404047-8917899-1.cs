    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pan1.Attributes.Add("onclick", "javascript:alert('here');return false;");
        }
    }
