    [HttpPost]
    public ActionResult Create(MenuViewModel model)
    {
        if (ModelState.IsValid)
        {
           var menu = new Menu {Name = model.Name };//for example
           menu.Roles =  _db.UserRoles.Where(rl => model.SelectedRoles.Contains(rl.Id)).ToList();
           _db.SaveChanges();
           return RedirectToAction("Index");
        }
        return View(model);
    }
