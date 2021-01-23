    using (var db = new UserDbContext())
    {
        foreach (var userid in Enumerable.Range(1, 100))
        {
            var main = new MainTable { Name = "Main" + userid };
            db.MainEntries.Add(main);
            var extended = new ExtendedTable { AnotherTableColumn = "Extended" + userid, MainEntry = main };
            db.ExtendedEntries.Add(extended);
        }
        int recordsAffected = db.SaveChanges();
        foreach (var main in db.MainEntries)
            Console.WriteLine("{0}, {1}", main.Name, main.ThePrimaryKeyId);
        foreach (var extended in db.ExtendedEntries)
            Console.WriteLine("{0}, {1}, {2}, {3}", extended.AnotherTableColumn, extended.NotTheSameNameID, extended.MainEntry.Name, extended.MainEntry.ThePrimaryKeyId);
    }
