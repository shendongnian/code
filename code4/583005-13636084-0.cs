    public class MealsContext: DbContext
    {               
        public MealsContext() : base("ConnectionString")
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // mappings 
        }    
    
        public DbSet<Meal> Meals{ get; set; }
        public DbSet<Meat> Meats{ get; set; }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Drink> Drinks{ get; set; }
    }
