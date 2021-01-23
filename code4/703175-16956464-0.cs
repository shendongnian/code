    db.IncidentActions.Add(act);
                db.SaveChanges();
                Incident inc = new Incident
                {
                    IncidentID = ID,
                    StatusID = statID_new,
                    IncidentPendingDate = DateTime.Now
                };
                db.SaveChanges();
