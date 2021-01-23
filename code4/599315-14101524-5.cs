    public void EditStudent(People s)
    {
        var people = _db.People.First( p=> p.ID == s.ID); // Replace ID with primary key
         
      // Copy all properties from s to people
         
        _db.SaveChanges();
    }
