    public ActionResult Edit(int userId)
    { 
            var user = db.Users.Find(userId);
            
            if (TryUpdateModel(user))
            {                
                user.UsersDateCreated = UsersDateCreated;
                user.UsersDateModified = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
     }
