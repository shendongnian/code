    public class Keys_ByNameAndBlock : AbstractIndexCreationTask<Product, BlockResult>
    {
        public Keys_ByNameAndBlock()
        {
            Map = products =>
                  from product in products
                  where product.Block != null
                  select new
                      {
                          product.Name,
                          product.Block,
                          ProductIds = product.ProductKeys.Select(x => x.Id)
                      };
            Reduce = results =>
                     from result in results
                     group result by new {result.Name, result.Block}
                     into g
                     select new
                         {
                             g.Key.Name,
                             g.Key.Block,
                             ProductIds = g.SelectMany(x => x.ProductIds)
                         };
        }
         
    }
    public class Product
    {
        public Product()
        {
            ProductKeys = new List<ProductKey>();
        }
        public int ProductId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Block { get; set; }
        public IEnumerable<ProductKey> ProductKeys { get; set; }
    }
    public class ProductKey
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }
    public class BlockResult
    {
        public string Name { get; set; }
        public string Block { get; set; }
        public int[] ProductIds { get; set; }
    }
