    public class PasswordAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                string password = actionContext.Request.Headers.GetValues("Password").First();
                // instead of hard coding the password you can store it in a config file, database, etc.
                if (password != "abc123")
                {
                    // password is not correct, return 401 (Unauthorized)
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    return;
                }
            }
            catch (Exception e)
            {
                // if any errors occur, or the Password Header is not present we cannot trust the user
                // log the error and return 401 again
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
        }
    }
    [PasswordAuthorize]
    public class YourController : ApiController
    {
    }
