    [Authorize]
        public class AccountController : Controller
        {
      [AllowAnonymous]
            public ActionResult Login(string returnUrl)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
    
            //
            // POST: /Account/Login
            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
            {
                if (ModelState.IsValid)
                {
    
                    // find user by username first
                    var user = await UserManager.FindByNameAsync(model.Email);
    
                    if (user != null)
                    {
                        var validCredentials = await UserManager.FindAsync(model.Email, model.Password);
    
                        // When a user is lockedout, this check is done to ensure that even if the credentials are valid
                        // the user can not login until the lockout duration has passed
                        if (await UserManager.IsLockedOutAsync(user.Id))
                        {
                            ModelState.AddModelError("", string.Format("Invalid credentials. Please try again, or contact support", 60));
                        }
                        // if user is subject to lockouts and the credentials are invalid
                        // record the failure and check if user is lockedout and display message, otherwise,
                        // display the number of attempts remaining before lockout
                        else if (await UserManager.GetLockoutEnabledAsync(user.Id) && validCredentials == null)
                        {
                            // Record the failure which also may cause the user to be locked out
                            await UserManager.AccessFailedAsync(user.Id);
    
                            string message;
    
                            if (await UserManager.IsLockedOutAsync(user.Id))
                            {
                                message = string.Format("Invalid credentials. Please try again, or contact support", 60);
                            }
                            else
                            {
                                int accessFailedCount = await UserManager.GetAccessFailedCountAsync(user.Id);
    
                                int attemptsLeft = (5 - accessFailedCount);
    
                                message = string.Format("Invalid credentials. Please try again, or contact support.", attemptsLeft);
                            }
    
                            ModelState.AddModelError("", message);
                        }
                        else if (validCredentials == null)
                        {
                            ModelState.AddModelError("", "Invalid credentials. Please try again, or contact support.");
                        }
                        else
                        {
                            await SignInAsync(user, model.RememberMe);
    
                            // When token is verified correctly, clear the access failed count used for lockout
                            await UserManager.ResetAccessFailedCountAsync(user.Id);
    
                            return RedirectToLocal(returnUrl);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", string.Format("Invalid credentials. Please try again, or contact support", 60));
                    }
                }
                // If we got this far, something failed, redisplay form
                return View(model);
            }
    
      [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindByNameAsync(model.Email);
                    if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                    {
                        // Don't reveal that the user does not exist or is not confirmed
                        //ModelState.AddModelError("", "The user either does not exist or is not confirmed.");
                        return RedirectToAction("ForgotPasswordConfirmation", "Account");
                    }
                    else
                    {
                        var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                        var callbackUrl = Url.Action("ResetPassword", "Account",
                        new { UserId = user.Id, code = code }, protocol: Request.Url.Scheme);
    
                        string Data = System.IO.File.ReadAllText(Server.MapPath(@"~/documents/email_password_reset.txt"));
    
                        AspNetUser oUser = dbPortal.AspNetUsers.Find(user.Id);
                        // can't use string.format becuase of CSS                
                        Data = Data.Replace("{0}", oUser.Name);  // user name
                        Data = Data.Replace("{1}", callbackUrl); // URL to click
                        Data = Data.Replace("{2}", DateTime.Now.Year.ToString()); // copyright year
                        await UserManager.SendEmailAsync(user.Id, "Reset Password", Data);
                        return RedirectToAction("ForgotPasswordConfirmation", "Account");
                    }
                }
    
                // If we got this far, something failed, redisplay form
                return View(model);
    
            }
    
            //
            // GET: /Account/ForgotPasswordConfirmation
            [AllowAnonymous]
           public async Task<ActionResult> ForgotPasswordConfirmation()
            {
                return View();
            }
    }
