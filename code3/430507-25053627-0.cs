        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            Mail email= new Mail();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    email.to = new MailAddress(model.Email);
                    email.body = "Hello " + model.Firstname + " your account has been created <br/> Username: " + model.UserName + " <br/>Password: " + model.Password.ToString() + " <br/> change it on first loggin";
                    ViewBag.Feed = email.reg();
                    
                    await SignInAsync(user, isPersistent: false);
                    
                    
                     return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
   
