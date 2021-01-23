    using (var db = new SQLiteConnection(dbPath))
    {
        db.RunInTransaction(() =>
        {
            foreach (var item in items)
            {
                db.Insert(item);
            }
        });
    }
    
