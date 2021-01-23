    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
      {
        var modifiedEntities = this.ChangeTracker.Entries().Where(c => c.State == EntityState.Modified);
        foreach (var entityEntry in modifiedEntities)
        {
          if (entityEntry.Entity is ChildObject)
          {
             var fkProperty = entityEntry.Property(nameof(ChildObject.ParentObjectId));
             if (fkProperty.IsModified && fkProperty.CurrentValue == null && fkProperty.OriginalValue != null)
             {
               // Checked if FK was set to NULL
               entityEntry.State = EntityState.Deleted;
             }
        }
    
        return await base.SaveChangesAsync(cancellationToken);
      }
