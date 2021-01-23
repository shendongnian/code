    [HttpPost]
    public ActionResult Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            // Attempt to register the user
            MembershipCreateStatus createStatus;
            Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);
            if (createStatus == MembershipCreateStatus.Success)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
               //Get UserId for registered user
                var UserId = (Guid)Membership.GetUser(model.UserName).ProviderUserKey;
                ExtendedUser extrainfo = new ExtendedUser();
                extrainfo.UserId = UserId;
                extrainfo.FirstName= model.FirstName;
                extrainfo.LastName= model.LastName;
                //Add this info to database
                db.ExtendedUsers.Add(extrainfo);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", ErrorCodeToString(createStatus));
            }
        }
        // If we got this far, something failed, redisplay form
        return View(model);
    }
