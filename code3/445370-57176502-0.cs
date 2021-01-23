    {
        class Program
        {
            public static List<Product> list;
            static void Main(string[] args)
            {
    
                list = new List<Product>() { new Product() { ProductId=1, Name="Nike 12N0",Brand="Nike",Price=12000,Quantity=50},
                     new Product() { ProductId =2, Name = "Puma 560K", Brand = "Puma", Price = 120000, Quantity = 55 },
                     new Product() { ProductId=3, Name="WoodLand V2",Brand="WoodLand",Price=21020,Quantity=25},
                     new Product() { ProductId=4, Name="Adidas S52",Brand="Adidas",Price=20000,Quantity=35},
                     new Product() { ProductId=5, Name="Rebook SPEED2O",Brand="Rebook",Price=1200,Quantity=15}};
    
              
                Console.WriteLine("Enter ProductID to remove");
                int uno = Convert.ToInt32(Console.ReadLine());
                var itemToRemove = list.Find(r => r.ProductId == uno);
                if (itemToRemove != null)
                    list.Remove(itemToRemove);
                Console.WriteLine($"{itemToRemove.ProductId}{itemToRemove.Name}{itemToRemove.Brand}{itemToRemove.Price}{ itemToRemove.Quantity}");
                Console.WriteLine("------------sucessfully Removed---------------");
    
                var query2 = from x in list select x;
                foreach (var item in query2)
                {
                    /*Console.WriteLine(item.ProductId+" "+item.Name+" "+item.Brand+" "+item.Price+" "+item.Quantity );*/
                    Console.WriteLine($"{item.ProductId}{item.Name}{item.Brand}{item.Price}{ item.Quantity}");
                }
    
            }
           
        }
    }
