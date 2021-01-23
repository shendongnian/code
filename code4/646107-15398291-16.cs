    //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var db = new UsersContext();
                // Attempt to register the user
                try
                {
                   var userProfile = WebSecurity.CreateUserAndAccount(model.UserName, model.Password, null, false);
                    //var userProfile= db.UserProfile.SingleOrDefault(u => u.UserName == model.UserName);
                    
                    if (userProfile!= null) //This way Userdetail is only created if UserProfile exists so that it can retrieve the foreign key
                    {
                        var userDetail = new UserDetail
                                               {
                                                   UserProfile = userProfile,
                                                   FirstName = model.FirstName,
                                                   LastName = model.LastName
                                               };                                                
                                                                                                                               
                        db.UserDetails.Add(userDetail);
                        db.SaveChanges();
                    }                    
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
