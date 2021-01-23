    namespace TestUserControls
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                UserControl1.MyCustomClickEvent += UserControl2.HandleCustomEvent;
            }
        }
    }
