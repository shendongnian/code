        public class Product
        {
            public string ProductName { get; set; }
            public decimal ProductValue { get; set; }
            public decimal ProductResult { get; set; }
        }
            var products = new List<Product>()
            {
                new Product () {ProductName = "product1", ProductValue = 10},
                new Product () {ProductName = "product2", ProductValue = 20},
                new Product () {ProductName = "product3", ProductValue = 30},
            };
            var results = new List<Dictionary<string, decimal>>();
            foreach (var product in products)
            {
                product.ProductValue = GetRatePerProduct(product.ProductName);
            }
            // the next two lines do exactly the same thing, just one of them is explicitly parallelized
            products.ForEach(product => { product.ProductValue = GetRatePerProduct(product.ProductName); });
            Parallel.ForEach(products, product => { product.ProductValue = GetRatePerProduct(product.ProductName); });
