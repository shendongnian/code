    public class MvcApplication : System.Web.HttpApplication
    {
      public MvcApplication()
      {
        Error += MvcApplication_Error;
      }
      private void MvcApplication_Error(object sender, EventArgs e)
      {
        Exception exception = application.Server.GetLastError();
        ...process exception...
        // clear the exception from the server
        application.Server.ClearError();
      }
    }
