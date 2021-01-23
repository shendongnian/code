                var filePath = @"C:\Eastpoint\TestApps\TestHunterSuppliers\bin\Debug\Sample.xml";
                var serializer = new XmlSerializer(typeof(Products));
    
                //Setting dummy object to create the xml
                Products myProducts = new Products { Product = new Product { Name = "Papers", Price = new Price { Amount = "10", Value = "20" } } };
    
                var strWrite = new FileStream(filePath, FileMode.Create);
                serializer.Serialize(strWrite, myProducts);
                strWrite.Close();
    
    
                //////////////////////////////
    
                var strRead = new FileStream(filePath, FileMode.Open);
                var products = (Products)serializer.Deserialize(strRead);
                strRead.Close();
                
                Console.WriteLine(products.Product.Name);
                Console.WriteLine(products.Product.Price.Amount);
