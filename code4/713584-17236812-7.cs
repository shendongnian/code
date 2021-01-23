    using (var db = new LocatorContext ())
    {
        {
            db.Database.Initialize(true);
        }
    }
