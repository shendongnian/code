            public ActionResult Login(LoginModel model, string returnUrl)
            {
                try
                {
                    // try to auth user via AD
                    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
                    {
                        if (pc.ValidateCredentials(model.UserName, model.Password))
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, false);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    // try the default membership auth if active directory fails
                    if (Membership.ValidateUser(model.UserName, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, false);
    
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login failed");
                    }
                }
                catch
                {
                }
                GetErrorsFromModelState();
                return View(model);
            }
