        public static List<ProductCategory> GetCategories()
        {
            var db = new AdventureWorksEntities();
            try
            {
                if (!db.ProductCategories.Any())
                {
                    Console.WriteLine("Nothing in DB for ProductCategories");
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());
            }
            var data = from o in db.ProductCategories orderby o.Name select o;
            return data.ToList();
        }
