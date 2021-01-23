    public class Vitamin 
    {
        [Key]
        public String Name {get; set;}
        public double Amount {get; set;}
        public virtual Food Food {get; set;}
    }
    public class Food
    {
        [Key]
        public int FoodID {get; set;}
        public String FoodName {get; set;}
        public virtual List<Vitamin> Vitamins {get; set;}
    }
    public DataContext: DbContext 
    {
         public DbSet<Vitamin> Vitamin {get; set;}
         public DbSet<Food> Foods {get; set;}
    }
