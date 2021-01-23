     public class Global : HttpApplication
        {
            protected void Application_BeginRequest(object sender, EventArgs e)
            {
              if(ShouldValidate() && !IsValidRequest()){
                  //add your custom error status here perhaps
                  Response.StatusCode = 400
                  Response.StatusDescription = "Something Bad happened"
                  HttpContext.Current.Response.End()
              }
            }
