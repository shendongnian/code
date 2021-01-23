    namespace WebApplication2
    {
        public partial class Login : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void btnLogin_Click(object sender, EventArgs e)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    string username = Username.Text;
                    string password = Password.Text;
                    //Logic here
                }
            }
    
        }
    }
