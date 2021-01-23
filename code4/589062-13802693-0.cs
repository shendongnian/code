    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
             ///filterContext should contain the id you will need to clear up the file.
        }
    }
