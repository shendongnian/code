    public ActionResult Edit(User user)
    { 
            if (ModelState.IsValid)
            {
                var OldInsObj = db.Users.Find(user.UserId);
                DateTime UsersDateCreated = (DateTime)db.Entry(OldInsObj).Property("UsersDateCreated").CurrentValue;
                user.UsersDateCreated = UsersDateCreated;
                user.UsersDateModified = DateTime.Now;
                db.Entry(OldInsObj).State = EntityState.Detached;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
     }
