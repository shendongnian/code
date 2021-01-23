    public class Dependent
    {
        public int Id { get; set; }
        [Required]
        public Principal PrincipalEntity { get; set; }
        
    }
    public class Principal
    {
        public int Id { get; set; }
        public ICollection<Dependent> DependentEntities { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Principal> Principals { get; set; }
    }
