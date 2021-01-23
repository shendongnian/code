    namespace WebApplication1
    {
        public partial class MyUserControl : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                MyClass obj = new MyClass();
                myGridView.DataSource = obj.Save();
                myGridView.DataBind();
            }
        }
    }
