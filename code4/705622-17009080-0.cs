    [HttpGet]
    public ActionResult Edit(int userId)
    {
        var user = db.Users.SingleOrDefault(u => u.UserID == userId);
        if user != null)
        {
            return View(UserUpdatModel.FromUser(user));
        }
        // do whatever you do to handle errors
    }
    [HttpPost]
    public ActionResult Edit(UserUpdateModel user)
    {
        if (ModelState.IsValid)
        {
            var userToUpdate = db.Users.SingleOrDefault(u => u.UserID == user.UserID);
            if (userToUpdate != null)
            {
                // update fields in userToUpdate with data from user
                db.SaveChanges();
            }
        }
        // do whatever you do to handle errors
    }
