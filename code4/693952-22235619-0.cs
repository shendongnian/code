    public class FruitFarmContext : DbContext
    {
        public DbSet<Farm> Farms { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farm>().HasMany(Farm.FruitsExpression).WithMany();
        }
    }
    public class Farm
    {
        public int Id { get; set; }
        protected virtual ICollection<Fruit> Fruits  { get; set; }
        public static Expression<Func<Farm, ICollection<Fruit>>> FruitsExpression = x => x.Fruits;
        public IEnumerable<Fruit> FilteredFruits
        {
            get
            {
                //Apply any filter you want here on the fruits collection
                return Fruits.Where(x => true);
            }
        }
    }
    public class Fruit
    {
        public int Id { get; set; }
    }
