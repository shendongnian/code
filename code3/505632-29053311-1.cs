        public Products Get()
        {
            return new Products
            {
                AllProducts = new List<Product>
                {
                    new Product {Id = 1, Name = "Product1", Quantity = 20},
                    new Product {Id = 2, Name = "Product2", Quantity = 37},
                    new Product {Id = 3, Name = "Product3", Quantity = 6},
                    new Product {Id = 4, Name = "Product4", Quantity = 2},
                    new Product {Id = 5, Name = "Product5", Quantity = 50},
                }
            };
        }
