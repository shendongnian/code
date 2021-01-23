    public void Update(User user)
    {
        db.Entry(user).State = EntityState.Modified;
        db.SaveChanges();
    }
