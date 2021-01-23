    public class RecettesMaisonContext : DbContext
    {
        public RecettesMaisonContext()
            : base("RecettesMaison")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister =
                Assembly.GetExecutingAssembly().GetTypes().Where(
                    type =>
                    type.BaseType.IsGenericType &&
                    type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
    
            foreach (object configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
            }
        }
        ...
    }
