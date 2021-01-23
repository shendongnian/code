    // Thanks to LinqToSql you can define ur Sql-DB this way
    YourDBDataContext db = new YourDBDataContext();
    
    //
    // POST: /YourForm/Edit
    [HttpPost]
    public ActionResult Edit(YourModel model)
    {
        try
        {
            // if users not empty..
            if (model.users != null)
            {
                // Each User in Users
                foreach (var user in model.users)
                {   // Save it to your Sql-DB
                    db.Users.InsertOnSubmit(user);
                    db.SubmitChanges();
                }
            }
            // Return
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", new { ErrorMessage = "Message[" + ex.Message + "] - Source[" + ex.Source + "] - StackTrace[" + ex.StackTrace + "] - Data[" + ex.Data + "]" });
        }
    }
    //
    // GET: /YourForm/Error
    public ActionResult Error(String ErrorMessage)
    {
        ViewData["Error"] = ErrorMessage;
        return View();
    }
