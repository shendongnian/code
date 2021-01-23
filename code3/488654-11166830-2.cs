    [Authorize]
    public class AccountController : Controller
    {
    
            [AllowAnonymous]
            [HttpPost]
            public ActionResult Register(RegisterModel model)
            {
                if (ModelState.IsValid)
                {
                    // Attempt to register the user
                    MembershipCreateStatus createStatus;
                    Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);
    
                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", ErrorCodeToString(createStatus));
                    }
                }
    
                // If we got this far, something failed, redisplay form
                return View(model);
            }
    
    }
