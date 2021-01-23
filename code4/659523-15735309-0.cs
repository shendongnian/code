    [AttributeUsage(AttributeTargets.Class)]
    public class ErrorHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        readonly BaseController _bs = new BaseController();
        public virtual void OnException(ExceptionContext fc)
        {
            var model = new errors
            {
                stacktrace = fc.Exception.StackTrace,
                url = fc.HttpContext.Request.RawUrl,
                controller = fc.RouteData.GetRequiredString("controller"),
                source = fc.Exception.Source,
                errordate = DateTime.Now,
                message = fc.Exception.Message//,
                //InnExc = String.IsNullOrEmpty(fc.Exception.InnerException.ToString()) ? fc.Exception.InnerException.ToString() : ""
            };
            var message = "<html><head></head><body><h2>An error occured on " + _bs.GetKeyValue<string>("Mobile Chat App") + ".</h2>";
            message += "<strong>Message:</strong> <pre style=\"background-color:#FFFFEF\"> " + model.message + "</pre><br />";
            message += "<strong>Source:</strong> <pre style=\"background-color:#FFFFEF\">" + model.source + "</pre><br />";
            message += "<strong>Stacktrace:</strong><pre style=\"background-color:#FFFFEF\"> " + model.stacktrace + "</pre><br />";
            message += "<strong>Raw URL:</strong> <pre style=\"background-color:#FFFFEF\">" + model.url + "</pre></br />";
            message += "<strong>Inner Exception:</strong> <pre style=\"background-color:#FFFFEF\">" + model.InnExc + "</pre></br />";
            message += "<strong>Any Form values</strong>: <pre>" + fc.HttpContext.Request.Form + "</pre><br />";
            message += "</body></html>";
            fc.ExceptionHandled = true;
            fc.HttpContext.Response.Clear();
            fc.HttpContext.Response.StatusCode = 500;
            fc.HttpContext.Response.TrySkipIisCustomErrors = true;
            _bs.SendErrorMail(message);
            fc.ExceptionHandled = true;
            //var res = new ViewResult { ViewName = "error" };
            //fc.Result = res;
            fc.HttpContext.Response.Redirect("/ErrorPage");
            //fc.HttpContext.Response.RedirectToRoute("error",new{controller="Home",action="ErrorPage"});
        }
