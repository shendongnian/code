    public ActionResult AddRole() {
        var model = new RoleModel();
        //populate with any items needed for the Add Role Model View
        return View(model);
    }
