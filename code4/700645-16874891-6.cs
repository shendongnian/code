     public partial class UserControlTest : System.Web.UI.UserControl
     {
        protected void Page_Load(object sender, EventArgs e)
        { }
        
        public string FirstName
        {
            get { return txtUcFirstName.Text; }
            set { txtUcFirstName.Text = value; }
        }
     }
