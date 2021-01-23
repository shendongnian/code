    [HttpPost]
    public ActionResult _CreateUserName(UserNameModel userNameModel)
    {
        if (ModelState.IsValid)
        {
          using (var db = new DataConnection())
          {
            try
            {
                db.UsersTable.InsertOnSubmit(new User(){ Username = userNameModel});
                // Need to save what has been entered in the textbox 
                // to the Users table in the database. 
            }
            catch (Exception)
            {
                throw;
            }
        }
        return RedirectToAction("UserNamePage");
    }
    return View(userNameModel);
    }
