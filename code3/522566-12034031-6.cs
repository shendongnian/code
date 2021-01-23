    using (DbConnection db = GetDbConnection())
    {
      // do data-access stuff
      // ...
      db.Close(); //Useful
     // Some more code
    }
