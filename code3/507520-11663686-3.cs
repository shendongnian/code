                Club club1 = GetClubs("club1");
                Club club2 = GetClubs("club2");
                Club club3 = GetClubs("club3");
                ((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)club1);
                ((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)club2);
                ((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)club3);
                var test = club2.Members;
