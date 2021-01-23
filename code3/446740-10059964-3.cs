    public ActionResult Register()
    {
      RegisterViewModel objViewModel=new RegisterViewModel();
      objViewModel.Roles=GetAllRolesAs();  // returns the list of roles to this property
      return View(objViewModel);
    }
