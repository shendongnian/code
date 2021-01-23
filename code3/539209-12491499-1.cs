        public ActionResult Create(AccountUser user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    user.Password = user.Password.Encrypt();
                    userManager.AddUser(user);
                }
                catch (DbEntityValidationException dbex)
                {
                    foreach (var validationErrors in dbex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            ModelState.AddModelError(validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
    return PartialView("CreateUserPartial", user);
                }
                catch (DbUpdateException dbuex)
                {
                    if (dbuex.InnerException != null)
                        if (dbuex.InnerException.InnerException != null)
                            if (dbuex.InnerException.InnerException.Message.Contains("Cannot insert duplicate key row in object"))
                                return Content("User already exists!", "text/html");
                    else
                        ModelState.AddModelError("", "An unknown error occured when creating the user.");
    return PartialView("CreateUserPartial", user);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An unknown error occured when creating the user.");
    return PartialView("CreateUserPartial", user);
                }
    
    return PartialView("UsersPartial", userManager.GetUsers());
            }
    
            return PartialView("UsersPartial", userManager.GetUsers());
        }
