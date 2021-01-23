    using (var entities = new XEntities())
    {
        var product = entities.Products.SingleOrDefault(x => x.Id == id);
        product.Type = "New type"; // modifying
    
        int flag = entities.SaveChanges(); // 1
        // or await entities.SaveChangesAsync(); // 1
    }
