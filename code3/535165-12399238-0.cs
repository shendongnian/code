    public ActionResult CreateStaffPost(FormCollection input) {
        IContent staffUser = _contentManager.New("Staff_User");
        
        //Create the StaffUser
        _contentManager.Create(staffUser);
        //UserPart validation
        if (String.IsNullOrEmpty(input["user.Email"]))
            ModelState.AddModelError("Email", "The Email field is required.");
        //Check if user already exits
        var oldUser = _contentManager.Query("User").Where<UserPartRecord>(x => x.Email == input["user.Email"])
            .List()
            .FirstOrDefault();
        if (oldUser != null)
            ModelState.AddModelError("Email", "That email adress is already registered.");
        
        //This does all the work of hydrating your model
        var model = _contentManager.UpdateEditor(staffUser, this);
        if (!ModelState.IsValid) {   
            _transactionManager.Cancel();
            return View(model);
        }
        //Set Password
        _membershipService.SetPassword(userPart.As<UserPart>(), input["password"]);
        
        return RedirectToAction("Index");
    }
