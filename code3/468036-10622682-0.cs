    public class myPageClass : System.Web.UI.Page
        {
            public void authorize()
            { 
                // your auth code here
                Response.Redirect("Invalid_Permissions_Page.aspx", false);
            }
        }
----------
    public partial class _Default : myPageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Your code here
        }
    }
