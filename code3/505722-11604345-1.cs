    namespace TestUserControls
    {
        public partial class UserControl2 : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            public void HandleCustomEvent(object sender, MyCustomeEventArgs e)
            {
                GetAllItemsByRegistrantID(e.SearchID);
            }
    
            public void GetAllItemsByRegistrantID(int id)
            {
                Label1.Text = id.ToString();
            }
        }
    }
