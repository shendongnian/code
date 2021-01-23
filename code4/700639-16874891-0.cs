     public partial class UserControlTest : System.Web.UI.UserControl
     {
        protected void Page_Load(object sender, EventArgs e)
        { }
        
        public string FirstName
        {
        set { txtUcFirstName.Text = value; }
        }
     }
