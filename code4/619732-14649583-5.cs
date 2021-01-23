    // Add a single entity.
    context.E1s.Add(new1);
    var dontAddMeNow = (from e in context.ChangeTracker.Entries()
                        where !object.ReferenceEquals(e.Entity, new1)
                        select e).ToList();
    foreach (var e in dontAddMeNow)
    {
        e.State = System.Data.EntityState.Unchanged;  // Or Detached.
    }
