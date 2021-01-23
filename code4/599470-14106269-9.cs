    User entity = null;
    using (var db = new DbContext()) {
        entity = (from p in db.Users
                  where p.id == 1
                  select p).FirstOrDefault();
        System.Diagnostics.Trace.WriteLine(entity.Name); //Outputs "Jane Doe"
    }
    entity.Name = "John Doe" //Modified while no longer connected to database
    using (var db = new DbContext()) {
        db.Users.Attach(entity);
        db.Entry(entity).Property(a => a.Name).IsModified = true;
        db.SaveChanges();
        System.Diagnostics.Trace.WriteLine(entity.Name); //Now outputs "John Doe"
    }
