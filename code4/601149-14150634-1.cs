        public static List<ProductCategory> GetCategories()
        {
            var db = new AdventureWorksEntities();
            var data = from o in db.ProductCategories orderby o.Name select o;
            if (data == null || data.Count() == 0)
            {
                Console.WriteLine("Nothing in DB for ProductCategories");
            }
            return data.ToList();
        }
