    // add to the IncidentAction table.
                    db.IncidentActions.Add(act);
                    db.SaveChanges();
                    // Update the Incident Table.
                    Incident inc = (from i in db.Incidents
                                    where i.IncidentID == ID
                                    select i).First();
                    inc.StatusID = statID_new,
                    inc.IncidentPendingDate = DateTime.Now;
                    db.SaveChanges();
