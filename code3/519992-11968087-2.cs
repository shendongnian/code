    public class AgreedToDisclaimerAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
           if (httpContext == null)
            throw new ArgumentNullException("httpContext");
           // logic to check if they have agreed to disclaimer (cookie, session, database)
           return true;
        }
      }
