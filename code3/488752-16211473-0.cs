    public abstract class DbEntity
    {
        [Key, DatabaseGenerated(DatabaseGenerated.Identity)]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
    }
    public class Package : DbEntity
    {
        public string Name { get; set; }
        public List<Variant> Variants { get; set; }
    }
    public class Variant : DbEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
    
    public class Product : DbEntity
    {
        public string Name { get; set; }
    }
