    public ActionResult Edit(string Identification)
    {
        DATA2.User u = c.GetUserById(Identification);
        return View(u);
    }
