        var products = entities.SelectMany(element =>
            {
                var ProductEntities = new List<ProductEntity>();
                element.Product.Split(',').ToList().ForEach(product =>
                {
                    ProductEntities.Add(new ProductEntity { SNo = element.SNo, Product = product, Cost = element.Cost });
                });
                return ProductEntities;
            });
