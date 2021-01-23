     /// aspnetSQLMember Authentication
        if (ModelState.IsValid)
                    {
                        if (Membership.ValidateUser(model.UserName, model.Password))
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
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
                            ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        }
                    }
                    /// MVC4 simple membership authentication
                    /// if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
                    /// {
                    ///     return RedirectToLocal(returnUrl);
                    /// }
