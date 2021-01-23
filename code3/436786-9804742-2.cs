     public IEnumerable<IdNamePairBase> GetNamedDbSet( string dbSetName )
     {
          var property = this.GetType().GetProperty( dbSetName );
          if (property == null || !property.CanRead)
          {
             throw new ArgumentException("DbSet named " + dbSetName + " does not exist." );
          }
          // at this point you might want to check that the property is an enumerable type
          // and that the generic definition is convertible to IdNamePairBase by
          // inspecting the property type.  If you're sure that these hold, you could
          // omit the check.
          var result = new List<IdNamePairBase>();
          foreach (var item in (IEnumerable)property.GetValue( this, null))
          {
              result.Add( (IdNamePairBase)item );
          }
          return result;
     }
