    public static List<ProductCategory> GetCategories()
    {
        var db = new AdventureWorksEntities();
        if (!db.ProductCategories.Any())
        {
            Console.WriteLine("Nothing in DB for ProductCategories");
        }
        var data = from o in db.ProductCategories orderby o.Name select o;
        return data.ToList();
    }
