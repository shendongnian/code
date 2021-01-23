        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountEditModel model)
        {
            if (ModelState.IsValid)
            {
                if (HasSensitiveInformationChanged(model)) // model.EmailAddress.ToLower() != User.Identity.Name.ToLower()
                {
                    if (Membership.ValidateUser(User.Identity.Name, model.Password)) // && WebSecurity.IsCurrentUser(User.Identity.Name)) //redundant?
                    {
                        using (UsersContext db = new UsersContext())
                        {
                            UserProfile user = db.UserProfiles.FirstOrDefault(u => u.EmailAddress.ToLower() == User.Identity.Name.ToLower());
                            if (user != null)
                            {
                                user.EmailAddress = model.EmailAddress;
                                db.SaveChanges();
                                WebSecurity.Logout();
                                WebSecurity.Login(model.EmailAddress, model.Password);
                                return RedirectToAction("Index", "Search");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Could not find user. Please try logging in again.");
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("","Could not change email address. Please verify your password and try again.");
                    }
                }
                else
                {
                    //no change
                    return RedirectToAction("Index", "Search");
                }
            }
            return View("Index", model);
        }
