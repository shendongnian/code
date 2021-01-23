    using (var db = new DbContext()) {
        db.Users
            .Single(a => (a.Id == 1))
            .OnlineStatus = ((sbyte)status);
        db.SaveChanges();
    }
