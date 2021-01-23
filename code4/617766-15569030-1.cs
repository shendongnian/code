    if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    using( UsersContext dbContext = new UsersContext()){
                        dbContext.Physicians.Add(new Physician { UserName = model.UserName, Name = "testDoctor", PhysicianGUID = Guid.NewGuid() });
                        dbContext.SaveChanges();
                    }
                    WebSecurity.CreateAccount(model.UserName, model.Password);
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }
