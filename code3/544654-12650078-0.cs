    if (ModelState.IsValid)
    {
        var existingUser = db.Users.Single(p => /* query to find your user */);
        
        existingUser.From = user.From;
        existingUser.CC = user.CC;
        // etc.
        db.SaveChanges();
        
        return RedirectToAction("Index");
    }
