    // The AccountController has methods that only authorized
    // users should be able to access. However, we can override
    // this with another attribute for methods that anyone
    // can access
    [Authorize]
    public class AccountController : Controller
    {
        // This will allow the View to be rendered
        [AllowAnonymous]
        public ActionResult Register()
        {
            return ContextDependentView();
        }
            
            // This is one of the methods that anyone can access
            // Your Html.BeginForm will post to this method and
            // process what you posted.
            [AllowAnonymous]
            [HttpPost]
            public ActionResult Register(RegisterModel model)
            {
                // If all of the information in the model is valid
                if (ModelState.IsValid)
                {
                    // Attempt to register the user
                    MembershipCreateStatus createStatus;
                    Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);
                    
                    // If the out parameter createStatus gives us a successful code
                    // Log the user in
                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else // If the out parameter fails
                    {
                        ModelState.AddModelError("", ErrorCodeToString(createStatus));
                    }
                }
    
                // If we got this far, something failed, redisplay form
                return View(model);
            }
    
    }
