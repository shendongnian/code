    var name="NoteInternal";
    var entities = ChangeTracker.Entries()  
                                    .Where(e => e.State == EntityState.Added ||  
                                                e.State == EntityState.Modified)  
                                    .Where(e => e.CurrentValues.Any(c=>c.Name==name && string.IsNullOrWhiteSpace((string)c.CurrentValue)));  
        // Add Default values when Creating or Editing an Entity  
        string defaultvalue = "";  
        foreach (var entity in entities)  
        {  
           entity.Property(name).CurrentValue=defaultvalue;
        }  
