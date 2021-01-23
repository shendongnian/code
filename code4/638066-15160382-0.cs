    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        readonly CreditPointModelContext _ctx = new CreditPointModelContext();
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if(Authorize(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
            throw new HttpResponseException(challengeMessage);
            
        }
        private bool Authorize(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                //boolean logic to determine if you are authorized.  
                //We check for a valid token in the request header or cookie.
                
                
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
