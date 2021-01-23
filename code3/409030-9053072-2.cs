    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] categories = new string[] { "fiction", "non_fiction", "self_help" };
            Cat_DropDownList.DataSource = categories;
            Cat_DropDownList.DataBind();
        }
    
        protected void Submit_btn_Click(object sender, EventArgs e)
        {
        } 
    }
