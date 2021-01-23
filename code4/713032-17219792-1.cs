    using (var db = new MyEntities())
    {
        db.Order.AddObject(incident);
        
        foreach (var loc in model.LocationList)
        {
            var location = new Data.Location
            {
                PersonId = model.PersonId,
                SiteCode = loc.SiteCode,
                IncidentId = loc.IncidentId
            };
   
            db.Location.AddObject(location);
        }
        db.Comment.AddObject(comment);
        db.SaveChanges();
    }
