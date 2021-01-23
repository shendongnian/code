    public class TokenValidationAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(HttpActionContext actionContext)
      {
       string token;
     
       try
       {
        token = actionContext.Request.Headers.GetValues("Authorization-Token").First();
       }
       catch (Exception)
       {
        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
        {
         Content = new StringContent("Missing Authorization-Token")
        };
        return;
       }
     
       try
       {
        //This part is where you verify the incoming token
        AuthorizedUserRepository.GetUsers().First(x => x.Name == RSAClass.Decrypt(token));
        base.OnActionExecuting(actionContext);
       }
       catch (Exception)
       {
        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
        {
         Content = new StringContent("Unauthorized User")
        };
        return;
       }
        }
      }
    }
