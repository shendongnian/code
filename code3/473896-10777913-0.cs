        try
        {
            db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException e)
        {
            var entry = e.Entries.Single();
            entry.OriginalValues.SetValues(entry.CurrentValues);
            entry.CurrentValues.SetValues(entry.CurrentValues);
            db.SaveChanges();
        }
