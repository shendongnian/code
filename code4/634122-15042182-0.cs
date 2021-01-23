            var products = new List<Dictionary<string, decimal>>()
            {
                new Dictionary<string, decimal> {{"product1", 10}},
                new Dictionary<string, decimal> {{"product2", 20}},
                new Dictionary<string, decimal> {{"product3", 30}}
            };
            var results = new List<Dictionary<string, decimal>>();
            results.AddRange(products.Select(product =>
            {
                var resultDictionary = new Dictionary<string, decimal>();
                foreach (string key in product.Keys)
                {
                    resultDictionary.Add(key, GetRatePerProduct(key));
                }
                return resultDictionary;
            }));
