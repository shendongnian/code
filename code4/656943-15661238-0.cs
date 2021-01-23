    [HttpGet]
    [AllowAnonymous]
    public ActionResult Register(RegisterModel model, int? userID)
    {
    ModelState.Clear();
    
        if (userID != null && userID > 0)
        {
            int id = userID.Value;
            ExternalUser newUser = RepositoryHelper.GetExternalUserRepository().GetById(id);
    
            model.UserFirstName = newUser.NameFirst;
            model.UserLastName = newUser.NameLast;
        }
        return View(model);
    }
