    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserControlTest1.FirstName = txtFirstName.Text;
        }
    }
