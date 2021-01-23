     using(KezberPMDBDataContext db = new KezberPMDBDataContext())
     {
        if (!db.DatabaseExists())
        {
            db.DeleteDatabase();
        }
        db.CreateDatabase();
      }
