    public class My19June_A : DbContext
    {
        public DbSet<Employee> { get; set; }
        public DbSet<Role> { get; set; }
        static My19June_A()
        {
            Database.SetInitializer<RegistryContext>(new CreateInitializer());
        }
        class CreateInitializer : CreateDatabaseIfNotExists<RegistryContext>
        {
            protected override void Seed(RegistryContext context)
            {
                void Seed()
                {
                    var programmerRole = new Role() { RoleID = 101, RoleName = "Programmer" };
                    var managerRole = new Role() { RoleID = 102, RoleName = "Manager" };
                    context.Roles.Add(programmerRole);
                    context.Roles.Add(managerRole);
                    context.SaveChanges();        
                }
            }
        }
    }
