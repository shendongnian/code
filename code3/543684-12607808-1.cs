    public class Dependent
    {
        public int Id { get; set; }
        public int PrincipalEntity_Id { get; set; }
        [Required]
        [ForeignKey("PrincipalEntity_Id")]
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
