    public static void RestrictModifiedProps<ENT>(this DbContext context, ENT entity, IEnumerable<string> restrictedPropNames)
      where ENT : class
    {
    
      //Grab the meta entry that knows whether the entity/properties have been updated
      var entry = context.Entry(entity);
      if (entry == null) return;
    
      //loop over properties, only allow properties in the 
      //  restrictedPropNames list to be modified
      foreach (var propName in entry.CurrentValues.PropertyNames)
      {
        var prop = entry.Property(propName);
        if (!prop.IsModified) continue;
    
        prop.IsModified = restrictedPropNames.Any(O => O == propName);
      }
    }
