        static void Main(string[] args)
        {
            var prodCat = new ProductCategory()
            {
                Name = "Category 1"
            };
            var prod = new Product()
            {
                Name = "Product 1",
                Category = prodCat,
                Price = 19.95M
            };
            using (var context = new MyContext())
            {
                var initializer = new InitDb<MyContext>();
                initializer.InitializeDatabase(context);
                Console.WriteLine("Adding products and categories to context.");
                context.ProductCategories.Add(prodCat);
                context.Products.Add(prod);
                Console.WriteLine();
                Console.WriteLine("Saving initial context.");
                context.SaveChanges();
                Console.WriteLine("Context saved.");
                Console.WriteLine();
                Console.WriteLine("Changing product details.");
                var initProd = context.Products.Include(x => x.Category).SingleOrDefault(x => x.Id == 1);
                PrintProduct(initProd);
                initProd.Name = "Product 1 modified";
                initProd.Price = 29.95M;
                initProd.Category.Name = "Category 1 modified";
                PrintProduct(initProd);
                Console.WriteLine();
                Console.WriteLine("Saving modified context.");
                context.SaveChanges();
                Console.WriteLine("Context saved.");
                Console.WriteLine();
                Console.WriteLine("Getting modified product from database.");
                var modProd = context.Products.Include(x => x.Category).SingleOrDefault(x => x.Id == 1);
                PrintProduct(modProd);
                Console.WriteLine();
                Console.WriteLine("Finished!");
                Console.ReadKey();
            }
            
        }
        static void PrintProduct(Product prod)
        {
            Console.WriteLine(new string('-', 10));
            Console.WriteLine("Id      : {0}", prod.Id);
            Console.WriteLine("Name    : {0}", prod.Name);
            Console.WriteLine("Price   : {0}", prod.Price);
            Console.WriteLine("CatId   : {0}", prod.Category.Id);
            Console.WriteLine("CatName : {0}", prod.Category.Name);
            Console.WriteLine(new string('-', 10));
        }
