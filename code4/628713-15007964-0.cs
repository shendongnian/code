    public class oraDbContext : DbContext
    {
        static oraDbContext() {
            Database.SetInitializer<oraDbContext>(null);
        }
        private oraDbContext(DbConnection connection, DbCompiledModel model)
            : base(connection, model, contextOwnsConnection: false) { }
        public DbSet<SomeTable1> SomeTable1 { get; set; }
        public DbSet<SomeTable2> SomeTable2 { get; set; }
        private static ConcurrentDictionary<Tuple<string, string>, DbCompiledModel> modelCache = new ConcurrentDictionary<Tuple<string, string>, DbCompiledModel>();
        public static oraDbContext Create(string schemaName, DbConnection connection) {
            var compiledModel = modelCache.GetOrAdd(
                Tuple.Create(connection.ConnectionString, schemaName),
                t =>
                {
                    var builder = new DbModelBuilder();
                    builder.Configurations.Add<SomeTable1>(new SomeTable1Map(schemaName));
                    builder.Configurations.Add<SomeTable2>(new SomeTable2Map(schemaName));
                    var model = builder.Build(connection);
                    return model.Compile();
                });
            return new oraDbContext(connection, compiledModel);
        }
    }
