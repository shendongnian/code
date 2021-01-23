        public class MyAuthorizeAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var authorized = base.AuthorizeCore(httpContext);
                if (!authorized)
                {
                    return false;
                }
                return httpContext.Session["someKeyThatYouHaveStored"] != null;
            }
        }
