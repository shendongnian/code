    using(var db = new MyDbContext())
    {
        var b = db.A.Create<B>();
        // ... same for C and D
        db.A.Add(b);
        db.SaveChanges();
    }
