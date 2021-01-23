    var products = new List<Product> {
        new Product {
            Id = 1,
            Name = "TestName",
            SKU = new List<SKU> {
                new SKU { Name = "test", UPC = "UPC1" },
                new SKU { Name = "test2", UPC = "UPC2" }
            }
        },
        new Product {
            Id = 1,
            Name = "TestName",
            SKU = new List<SKU> { }
        }
    };
