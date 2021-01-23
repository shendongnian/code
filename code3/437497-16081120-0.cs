    foreach(Email email in User.Emails)
    {
        if(string.IsNullOrEmpty(email.Address))
        {
            db.Entry(email).State = System.Data.EntityState.Deleted;
        }
    }
    db.SaveChanges();
