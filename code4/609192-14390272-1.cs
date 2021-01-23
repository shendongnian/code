        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (UsersContext db = new UsersContext())
                {
                    UserProfile email = db.UserProfiles.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower());
                    try
                    {
                        // Check if email already exists
                        if (email == null)
                        {
                            WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { Email = model.Email });
                            WebSecurity.Login(model.UserName, model.Password);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("Email", "Email address already exists. Please enter a different email address.");
                        }
                    }
                    catch (MembershipCreateUserException e)
                    {
                        ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                    }
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
