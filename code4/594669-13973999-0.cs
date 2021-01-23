    public class Products_GroupedByClientNameAndBlock : AbstractIndexCreationTask<Product, Products_GroupedByClientNameAndBlock.Result>
    {
        public class Result
        {
            public string ClientName { get; set; }
            public string Block { get; set; }
            public IList<ProductKey> ProductKeys { get; set; }
        }
        public class ProductKey
        {
            public string Id { get; set; }
            public string Url { get; set; }
        }
        public Products_GroupedByClientNameAndBlock()
        {
            Map = products =>
                    from product in products
                    where product.Details.Block != null
                    select new {
                                    product.ClientName,
                                    product.Details.Block,
                                    ProductKeys = new[] { new { product.Id, product.Url } }
                                };
            Reduce = results =>
                        from result in results
                        group result by new { result.ClientName, result.Block }
                        into g
                        select new {
                                    g.Key.ClientName,
                                    g.Key.Block,
                                    ProductKeys = g.SelectMany(x => x.ProductKeys)
                                };
        }
    }
