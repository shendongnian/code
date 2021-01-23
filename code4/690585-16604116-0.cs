    public override int SaveChanges()
    {
        var changedEntries = ChangeTracker.Entries();
        if (changedEntries != null)
        {
            var dbEntityEntries = changedEntries as IList<DbEntityEntry> ?? changedEntries.ToList();
            dbEntityEntries.Select(i=>i.Entity).OfType<Project>().Distinct()
                .Union(dbEntityEntries.Select(i=>i.Entity).OfType<Activity>().Select(activity=>activity.Project))
                    .Union(dbEntityEntries.Select(i=>i.Entity).OfType<Action>().Select(action => action.Activity.Project))
            .Distinct().ToList()
            .ForEach(p => p.LastUpdateDate = DateTime.UtcNow);
        }
        return base.SaveChanges();
    }
