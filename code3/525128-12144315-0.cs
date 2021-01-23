    public class Global : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            Server.ClearError();
            Server.Transfer("~/GlobalExceptionHandler.aspx?ReturnUrl=" + Request.Path);
        }
    }
