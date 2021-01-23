    public void EditStudent(People s)
    {
        _db.People.First( p=> p.ID == s.ID); // Replace ID with primary key
         
      // Copy all properties from s to p
         
        _db.SaveChanges();
    }
