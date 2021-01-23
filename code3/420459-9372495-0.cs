    public partial class getData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            short index = System.Convert.ToInt16(Request.Form["i"]);  // BREAKPOINT
        }
    }
