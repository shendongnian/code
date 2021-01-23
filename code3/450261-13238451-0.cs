    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         var entityMapTypes = assembly.GetTypes().Where(
             (t => t.BaseType != null && t.BaseType.IsGenericType && 
                   t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)));
         foreach (var mapType in entityMapTypes)
         {
             dynamic configurationInstance = Activator.CreateInstance(mapType);
             modelBuilder.Configurations.Add(configurationInstance);
         }
    } 
