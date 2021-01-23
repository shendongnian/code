    StreamWriter writer = new StreamWriter("C:\\Users\\Alchemy\\Desktop\\c#\\InputFileFrmUser.csv");
    list = new List<Product>() { new Product() { ProductId=1, Name="Nike 12N0",Brand="Nike",Price=12000,Quantity=50},
            new Product() { ProductId =2, Name = "Puma 560K", Brand = "Puma", Price = 120000, Quantity = 55 },
            new Product() { ProductId=3, Name="WoodLand V2",Brand="WoodLand",Price=21020,Quantity=25},
            new Product() { ProductId=4, Name="Adidas S52",Brand="Adidas",Price=20000,Quantity=35},
            new Product() { ProductId=5, Name="Rebook SPEED2O",Brand="Rebook",Price=1200,Quantity=15}};
    foreach (var x in list) {
        string wr = x.ProductId + " " + x.Name + "" + x.Brand + " " + x.Quantity + " " + x.Price;
        writer.Flush();
        writer.WriteLine(wr);
    }
    Console.WriteLine("--------ProductList Updated SucessFully----------------");
