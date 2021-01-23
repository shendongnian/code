    using (var db = new MyContext())
    {
        {
            db.Database.Initialize(true);
        }
    }
