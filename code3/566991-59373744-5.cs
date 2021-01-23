protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "test1", "continiousRequestOfSessionState();", true);
        }
    }
}
