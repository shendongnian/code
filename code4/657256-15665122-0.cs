    public class CustomAuthAttribute : AuthorizeAttribute
    {
        public CustomAuthAttribute(AuthMethod method = AuthMethod.StandardAuth)
        {
            //stuff
        }
    }
    [CustomAuth(AuthMethod.WeirdAuth)]
    public ActionResult MethodThatNeedsDifferentAuth()
    {
        //stuff
    }
