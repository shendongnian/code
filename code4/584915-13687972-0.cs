    public partial class _Default : System.Web.UI.Page
    {
        //public  HttpResponse response;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this is enough
            Response.Redirect("http://www.google.com");
        }
    }
