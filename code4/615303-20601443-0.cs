    public class AccountController : Controller
    {
        public ActionResult SignIn(string returnUrl)
        {
            if (String.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.Content("~/");
            }
            var signInRequest = FederatedAuthentication.WSFederationAuthenticationModule.CreateSignInRequest(
                "passive",
                returnUrl,
                FederatedAuthentication.WSFederationAuthenticationModule.PersistentCookiesOnPassiveRedirects);
            return Redirect(signInRequest.RequestUrl);            
        }
        // SignOut, SignOutCallback below from typical MVC template
    }
