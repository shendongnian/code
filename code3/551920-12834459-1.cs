    namespace MvcApplicationTest.Models
    {
        public class Material
        {
            public int MaterialId { get; set; }
            public int Name { get; set; }
        }
    
        public class Plan
        {
            public int PlanId { get; set; }
            public int Name { get; set; }
    
            //full navigation property
            public virtual Material Material { get; set; }
            public int? MaterialId { get; set; } 
            //
    
        }
    
        public class TestContext : DbContext
        {
            public DbSet<Material> Materials { get; set; }
            public DbSet<Plan> Plans { get; set; }
        }
    }
