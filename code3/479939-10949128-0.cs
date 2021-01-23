    db.Users.Attach(user);
    var current = db.Entry(user).CurrentValues.Clone();
    db.Entry(user).Reload();
    //Do you user(from db) stuff
    db.Entry(user).CurrentValues.SetValues(current);
    db.Entry(user).State = EntityState.Modified;
    db.SaveChanges();
