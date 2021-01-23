    public class Global : System.Web.HttpApplication
    { ...
        void Application_AcquireRequestState(object sender, EventArgs e)
        {            
            HttpContext context = HttpContext.Current;
            // CheckSession() inlined
            if (context.Session["LoggedIn"] != "true")
            {
              context.Response.Redirect("default.aspx");
            }
        }
      ...
    }
