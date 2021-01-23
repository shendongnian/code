    public class ErrorModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.Error += context_Error;
        }
 
        void context_Error(object sender, EventArgs e)
        {
            var error = HttpContext.Current.Server.GetLastError() as HttpException;
            if (error.GetHttpCode() == 404)
            {
                //use web.config to find where we need to redirect
                var config = (CustomErrorsSection) WebConfigurationManager.GetSection("system.web/customErrors");
                context.Response.StatusCode = 404;
 
                string requestedUrl = HttpContext.Current.Request.RawUrl;
                string urlToRedirectTo = config.Errors["404"].Redirect;
                HttpContext.Current.Server.Transfer(urlToRedirectTo + "&errorPath=" + requestedUrl);
            }
        }
    }
