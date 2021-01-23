    // create a new list of your entity Location (may not be in namespace Data)
    var locationList = new List<Data.Location>();
    foreach (var loc in model.LocationList)
    {
        var location = new Data.Location
        {
            PersonId = model.PersonId,
            SiteCode = loc.SiteCode,
            IncidentId = loc.IncidentId
        };
        locationList.Add(location);
    }
    using (var db = new MyEntities())
    {
        db.Order.AddObject(incident);
        
        foreach (var item in LocationList)
        {
            db.Location.AddObject(location);
        }
        db.Comment.AddObject(comment);
        db.SaveChanges();
    }
