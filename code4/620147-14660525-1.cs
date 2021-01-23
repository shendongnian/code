    public ActionResult Show()
    {
        // entity model
        var user = _userRepository.GetUserByName(User.Identity.Name);
    
        // translate to view model
        var model = new User
        {
            Name = user.Name,
            EmailAddress = user.EmailAddress
        }
        // Send the view model to the view
        return View(model);
    }
