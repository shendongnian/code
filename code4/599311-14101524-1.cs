    public void DeleteStudent(People s)
    {
        _db.People.Remove(s);
        _db.SaveChanges();
    }
