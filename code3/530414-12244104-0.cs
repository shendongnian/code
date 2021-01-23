    [AttributeUsage(AttributeTargets.Class)]
    public class AuthenticationRequired : Attribute
    {
        public AuthenticationRequired(bool isMemberRequired)
        {
            if(isMemberRequired && !HttpContext.Current.User.Identity.IsAuthenticated)
            {
              FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
