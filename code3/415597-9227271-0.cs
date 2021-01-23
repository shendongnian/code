    public class MyContext : DbContext
    {
        public DbSet Document_head Document_head{ get; set; }
        public DbSet sales_order{ get; set; }
        modelBuilder.Entity‹sales_order›().HasRequired(p => p.Document_head)
             .WithOptional(p => p.sales_order);
    }
