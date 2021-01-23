    if( !string.IsNullOrEmpty( tenantSchema ) && !tenantSchema.Equals( "dbo", StringComparison.OrdinalIgnoreCase ) )
      {
        var executeAs = string.Format( "EXECUTE AS User = '{0}' WITH NO REVERT", tenantSchema );
        ( (System.Data.Entity.Infrastructure.IObjectContextAdapter)context ).ObjectContext.Connection.Open();
        ( (System.Data.Entity.Infrastructure.IObjectContextAdapter)context ).ObjectContext.ExecuteStoreCommand( executeAs );
      }
