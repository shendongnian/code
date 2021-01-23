    Database.SetInitializer(new DropCreateDatabaseAlways<Library>());
    using(var db = new Library())
    {
      db.Database.Initialize(true);
    }
