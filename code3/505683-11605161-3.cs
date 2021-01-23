    public partial class MyDBContext
    {
      public MyDBContext() : base() { }
      private MyDBContext(DbConnection connection, DbCompiledModel model) : base(connection, model, contextOwnsConnection: false) { }
    
      private static ConcurrentDictionary<Tuple<string, string>, DbCompiledModel> modelCache
          = new ConcurrentDictionary<Tuple<string, string>, DbCompiledModel>();
    
      public static MyDBContext Create(string tenantSchema, DbConnection connection)
      {
        var compiledModel = modelCache.GetOrAdd
        (
          Tuple.Create(connection.ConnectionString, tenantSchema),
          t =>
          {
            var builder = new DbModelBuilder();
            builder.Conventions.Remove<IncludeMetadataConvention>();
            builder.Entity<Location>().ToTable("Locations", tenantSchema);
            builder.Entity<User>().ToTable("Users", tenantSchema);
    
            var model = builder.Build(connection);
            return model.Compile();
          }
        );
    
      var context = new FmsDBContext(connection, compiledModel);
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
      return context;
      }
    }
