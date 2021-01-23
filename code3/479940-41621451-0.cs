    public ActionResult Edit(User user)
    {
        User oldUser = db.Users.AsNoTracking().Single(x=>x.id.equals(user.id));
        // oldUser object represents the user before the modification
        ...
        db.Entry(user).State = EntityState.Modified;
        db.SaveChanges();
    }
