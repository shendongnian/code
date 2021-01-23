                var filePath = @"C:\Eastpoint\TestApps\TestHunterSuppliers\bin\Debug\Sample.xml";
                var serializer = new XmlSerializer(typeof(Products));
    
                Price myPrice = new Price();
                myPrice.Amount = "10";
                myPrice.Value = "20";
    
                Product myProduct = new Product();
                myProduct.Name = "Papers";
                myProduct.Price = myPrice;
    
                Products myProducts = new Products();
                myProducts.Product = myProduct;
    
                var strWrite = new FileStream(filePath, FileMode.Create);
                serializer.Serialize(strWrite, myProducts);
                strWrite.Close();
    
    
                //////////////////////////////
    
                var strRead = new FileStream(filePath, FileMode.Open);
                var products = (Products)serializer.Deserialize(strRead);
                strRead.Close();
                
                Console.WriteLine(products.Product.Name);
                Console.WriteLine(products.Product.Price.Amount);
