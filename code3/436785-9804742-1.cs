     public IEnumerable<IdNamePairBase> GetNamedDbSet(string dbSetName)
     {
          var property = Type.GetType(dbSetName);
          if (property == null || !property.CanRead)
          {
             throw new ArgumentException("DbSet named " + dbSetName + " does not exist." );
          }
          // at this point you might want to check that the property is an enumerable type
          // and that the generic definition is convertible to IdNamePairBase by
          // inspecting the property type.  If you're sure that these hold, you could
          // omit the check.
          return Set(type).Cast<IdNamePairBase>();
     }
