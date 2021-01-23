    public class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyClass.Static.PageLoadCounter++;
        }
    }
