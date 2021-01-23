    using (ITAMEFContext db = new ITAMEFContext(ConnectionStrings.XYZConnectionString))
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    db.Configuration.LazyLoadingEnabled = false;
                    
                    var dbRollout = db.Rollouts.Find(rollout.Id);
                    FixUp(dbRollout, rollout);
                    db.SaveChanges();
                }
