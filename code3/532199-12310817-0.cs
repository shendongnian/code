    public ActionResult Edit(UserRole role)
    {
        var permissionNameList = (from per in _db.Permissions
                                  select per.Name).Distinct().ToList();
        var realRole = (from r in _db.UserRoles
                        where r.Id == role.Id
                        select r).First();
        foreach (var perm in realRole.Permissions)
        {
            var opert = Convert.ToInt32(Request.Form[perm.Name + "_op"]);
            if (perm.Name.InList(permissionNameList))
            {
                perm.Operations = opert;
            }
        }
        if (ModelState.IsValid)
        {
            _db.Entry(realRole).State = System.Data.EntityState.Modified;
            _db.SaveChanges();
        }
        this.TempData["msg"] = "[EditRolePermissions]Saved Role Id " + role.Id;
        return RedirectToAction("Details/" + role.Id);
    }
