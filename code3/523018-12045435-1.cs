    public ActionResult Edit(Guid Id)
    {
        var model = new UserViewModel
        {
            UserGroups = new SelectList(GetAllUsers(), "UserId", "Name")
        }
        return View(model);
    }
