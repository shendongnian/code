    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request["btnGreen"] != null)
            {
                Page.MasterPageFile = "/Green.Master";
            }
            else if (Request["btnBlue"] != null)
            {
                Page.MasterPageFile = "/Blue.Master";
            }
        }
        
    }
