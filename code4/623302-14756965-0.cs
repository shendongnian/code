    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), 
                    "openTicketsScript", string.Format("openticketPageLoad({0});", Request.QueryString["ID"]), true);
        }
    }
