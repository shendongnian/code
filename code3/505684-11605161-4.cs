    if( !string.IsNullOrEmpty( tenantSchema ) && !tenantSchema.Equals( "dbo", StringComparison.OrdinalIgnoreCase ) )
      {
        var objectContext = ( (IObjectContextAdapter)context ).ObjectContext;
        objectContext.Connection.Open();
        var currentUser = objectContext.ExecuteStoreQuery<UserContext>( "SELECT CURRENT_USER AS Name", null ).FirstOrDefault();
        if( currentUser.Name.Equals( tenantSchema, StringComparison.OrdinalIgnoreCase ) )
        {
          var executeAs = string.Format( "REVERT; EXECUTE AS User = '{0}';", tenantSchema );
          objectContext.ExecuteStoreCommand( executeAs );
        }
      }
