    //I'm assuming that Files is the class of your page, and not just another class. Make sure that your markup inherits from this class
    public partial class Files : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Status.Text="Hello";
        }
    }
