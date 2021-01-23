    using (var db = new MyDbContex()
    {
        // get product with id == 1
        Product product = db.Products.Single(p => p.Id == 1);
    }
