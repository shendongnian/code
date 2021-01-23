    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginID"] != null)
                Label1.Text="Welcome :: " + Session["LoginID"].ToString();
            else
                Response.Redirect("Login.aspx");
    
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["LoginID"] = null;
            Response.Redirect("Login.aspx");
    
        }
    }
