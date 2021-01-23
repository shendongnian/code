    using (var db = new DbContext()) {
        foreach (var item in entityList) {
            var entity = db.Users.Single(a => a.id == item.id);
            entity.Name = item.Name;
            entity.Address = item.Address;
        }
        db.SaveChanges();
    }
