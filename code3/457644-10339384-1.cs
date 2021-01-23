    public class ManagerIdAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // the next line needs improvement, only works on an httpGet since retrieves
            // the id from the url.  Improve this line to obtain the id regardless of 
            // the  method (GET, POST, etc.)
            var id = filterContext.HttpContext.Request.QueryString["id"];
            var employee = employeeRepository.Get(id);
            var user = filterContext.HttpContext.User.Identity;
            if (employee.managerId  == user.managerId)
            {
                var res = filterContext.HttpContext.Response;
                res.StatusCode = 402;
                res.End();
                filterContext.Result = new EmptyResult();  //may use content result if want to provide additional info in the error message.
            }
            else
            {
                // OK, let it through.
            }
        }
    }
