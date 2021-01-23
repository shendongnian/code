    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    
    namespace System.Web.Http.Filters
    {
        public class ValidationActionFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var modelState = actionContext.ModelState;
    
                if (!modelState.IsValid)
                    actionContext.Response = actionContext.Request
                         .CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            }
        }
    }
