    public class ProductIndex : AbstractIndexCreationTask<Product,ProductIndex.ProductIndexItem>
    {
        public class ProductIndexItem
        {
            public string Name { get; set; }
            public string CategoryName { get; set; }
            public string CategoryNameAnalyzed { get; set; }
        }
        public ProductIndex()
        {
            Map = products => from product in products
                              from category in product.Categories
                              select new
                                  {
                                      product.Name,
                                      CategoryName = category.Name,
                                      CategoryNameAnalyzed = category.Name,
                                  };
            Stores.Add(x => x.CategoryName, FieldStorage.Yes);
            Analyzers.Add(x => x.CategoryNameAnalyzed, "SimpleAnalyzer");
        }
    }
	
