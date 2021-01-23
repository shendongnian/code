    class Program
        {
            static void Main(string[] args)
            {
                var list = new List<Product>
                    {
                        new Product() {Name = "Cornflakes", Price = 100},
                        new Product() {Name = "Cornflakes", Price = 200},
                        new Product() {Name = "Rice Krispies", Price = 300},
                        new Product() {Name = "Cornflakes", Price = 400}
                    };
    
                var uniqueItems = list.Where(w => (!list.Any(l=>l.Name.Equals(w.Name) && l != w)));
    
            }
    
            public class Product
            {
             
                public string Name { get; set; }
                public decimal Price { get; set; }
            }
        }
