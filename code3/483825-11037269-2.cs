    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }
            var rd = httpContext.Request.RequestContext.RouteData;
    
            var id = rd.Values["id"];
            var userName = httpContext.User.Identity.Name;
    
            Submission submission = unit.SubmissionRepository.GetByID(id);
            User user = unit.UserRepository.GetByUsername(userName);
    
            return submission.UserID == user.UserID;
        }
    }
