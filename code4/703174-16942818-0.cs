    Context db = new Context();
    var now = DateTime.Now;
    IncidentAction act = new IncidentAction
    {
        IncidentID = ID,
        ...
        LastUpdated = DateTime.Now,
    };
    db.IncidentActions.Add(act);
    
    Incident inc = db.Incidents.First(i => i.IncidentID == ID);
    inc.StatusID = statID_newl
    inc.IncidentPendingDate = now;
    db.SaveChanges();
