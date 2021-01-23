    // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    DateTime rightNow = DateTime.Now;
                    
                    //WebSecurity.CreateUserAndAccount(model.UserName, model.Password); //too limited used CreateUserAndAccount method below
                    var extendedUserProperties = new { SubscriberId = subscriber.SubscriberId, Email = model.Email, DateAdded = rightNow };
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, extendedUserProperties);
                    Roles.AddUserToRole(model.UserName, Request.Form["RoleName"]);
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
