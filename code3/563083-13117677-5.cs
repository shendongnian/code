    public ActionResult Create()
    {
      var model = new MenuViewModel();
      model.ParentMenuList = new SelectList(_db.Menus, "Id", "Name");
      model.RoleList = new SelectList(_db.UserRoles.ToList(), "Id", "Name");
      return View(model);
    }
