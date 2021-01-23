    using (var db = new CAPSContainer())
    {
        db.Attach(c);
        c.Trailers.Remove(t);
        db.SaveChanges();
    }
