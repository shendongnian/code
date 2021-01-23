    var incidentInitializer = new Action<Incident>(incident =>
    {
      incident.AccountID = AccountID,
      incident.SiteID = siteID,
      ...
    };
    // Save the data to the database
    if (Request.QueryString["IncidentID"] == null)
    {
        // Insert a new incident.
        var inc = new Incident();
        incidentInitializer(inc);
        db.Incidents.Add(inc);
        db.SaveChanges();
    }
    else
    {
        //update an existing incident.
        long ID = Convert.ToInt64(Request.QueryString["IncidentID"]);
        var record = db.Incidents.Where(i => i.IncidentID == ID).FirstOrDefault();
        incidentInitializer(record);
        db.SaveChanges();
    }
