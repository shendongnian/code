    var element = XElement.Load(@"C:\div_kid.xml");
    var shopsQuery =
        from shop in element.Descendants("shop")
        select new
        {
            Name = (string) shop.Descendants("name").FirstOrDefault(),
            Company = (string) shop.Descendants("company").FirstOrDefault(),
            Categories = 
                from category in shop.Descendants("category")
                select new {
                    Id = category.Attribute("id").Value,
                    Parent = category.Attribute("parentId").Value,
                    Name = category.Value
                },
            Offers =
                from offer in shop.Descendants("offer")
                select new { 
                    Price = (string) offer.Descendants("price").FirstOrDefault(),
                    Picture = (string) offer.Descendants("picture").FirstOrDefault()
                }
    
        };
    
    foreach (var shop in shopsQuery){
        Console.WriteLine(shop.Name);
        Console.WriteLine(shop.Company);
        foreach (var category in shop.Categories)
        {
            Console.WriteLine(category.Name);
            Console.WriteLine(category.Id);
        }
        foreach (var offer in shop.Offers)
        {
            Console.WriteLine(offer.Price);
            Console.WriteLine(offer.Picture);
        }
    }  
