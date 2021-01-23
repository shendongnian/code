    public ActionResult LogOn(LogOnModel model)
    {
        // Is model valid?
        if (!ModelState.IsValid)
        {
            this.ViewData["LogOnError"] = "Bad Credentials.";
            return this.View(model);
        }
        // Is user valid?
        if(!MembershipService.ValidateUser(model.UserName, model.Password))
        {
            this.ViewData["LogOnError"] = "Wrong Credentials.";
            return this.View(model);
        }
        MembershipUser user = Membership.GetUser(model.UserName);
        // Was the user deleted in the last nano-second?
        if (user == null)
        {
            this.ViewData["LogOnError"] = "Race Condition: User previously deleted.";
            return this.View(model);
        }
        // Is user locked out?
        if(user.IsLockedOut)
        {
            this.ViewData["LogOnError"] = "You are locked out.";
            return this.View(model);
        }
        // Sign the user in.
        FormsService.SignIn(model.UserName, model.RememberMe);
        return this.View("LogOnSuccessful");
    }
