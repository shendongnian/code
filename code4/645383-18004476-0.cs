    db.Users.Attach(updatedUser);
    var entry = db.Entry(updatedUser);
    entry.State = EntityState.Modified;
    entry.Property(e => e.Password).IsModified = false;
    entry.Property(e => e.SSN).IsModified = false;   
 
    db.SaveChanges();   
