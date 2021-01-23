    using System;
    using System.Web.Http;
    using System.Net.Http;
    public class AuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            HandleUnauthorizedRequest(actionContext);
        }
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Redirect);
            response.Headers.Add("Location", "http://www.google.com");
            actionContext.Response = response;
        }
    }
