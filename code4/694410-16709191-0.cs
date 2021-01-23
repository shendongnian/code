    Incident inc;
    
    if (Request.QueryString["IncidentID"] == null)
    {
        inc = new Incident();
        // set properties that are specific to insert
        db.Incidents.Add(inc);
    }
    else 
    {
        long ID = Convert.ToInt64(Request.QueryString["IncidentID"]);
        inc = db.Incidents.Where(i => i.IncidentID == ID).First();    
        // set properties that are specific to update
    }
    
    // set common properties
    db.SaveChanges();
