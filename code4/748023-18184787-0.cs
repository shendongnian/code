    MainDataContext db = new MainDataContext();
    try
    {
       var user = db.Users.SingleOrDefault(x => x.Username == username);
       if (user == null) return ValidationResult.Success;
           return new ValidationResult("Username already taken");
    }
    finally
    {
        if (db != null)
          ((IDisposable)db).Dispose();
    }
