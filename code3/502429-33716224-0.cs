    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["RoleId"] == null || Session["RoleId"].ToString() == "")
            {
                Response.Redirect("/account", true);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    setUserInfo();
            }
        }
    }
