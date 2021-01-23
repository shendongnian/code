    public class DataLayerBuilder : DbContext
    {
        private static  string conStr = string.Empty ;
        private DataLayerBuilder(DbConnection connection, DbCompiledModel model)
        : base(connection, model, contextOwnsConnection: false){ }
        public DbSet<Person> People { get; set; }
        
        private static ConcurrentDictionary<Tuple<string, string>, DbCompiledModel> modelCache
            = new ConcurrentDictionary<Tuple<string, string>, DbCompiledModel>();
        
        /// <summary>
        /// Creates a context that will access the specified tenant
        /// </summary>
        public static DataLayerBuilder Create(string tenantSchema)
        {
            conStr = ConfigurationManager.ConnectionStrings["ConnSTRName"].ConnectionString;
            var connection = new SqlConnection(conStr);
            var compiledModel = modelCache.GetOrAdd(
                Tuple.Create(conStr, tenantSchema),
                t =>
                {
                    
                    var builder = new DbModelBuilder();
                    builder.HasDefaultSchema(tenantSchema);
                    builder.Entity<Person>().ToTable("People");                   
                    builder.Entity<Contact>().ToTable("Contacts");
                    var model = builder.Build(connection);
                    return model.Compile();
                });
            return new DataLayerBuilder(connection, compiledModel);
        }
        /// <summary>
        /// Creates the database and/or tables for a new tenant
        /// </summary>
        public static void ProvisionTenant(string tenantSchema)
        {
            try
            {
                using (var ctx = Create(tenantSchema))
                {
                    if (!ctx.Database.Exists())
                    {
                        ctx.Database.Create();
                    }
                    else
                    {
                        ctx.Database.Initialize(true);
                       
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
