    public partial class MasterPages_MyTopMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Databind this to ensure user controls will behave
            this.DataBind();
        }
    }
