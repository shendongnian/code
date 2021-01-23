    using (var db = new MyDbContex()
    {
        Product product = new Product() { Id = 1, Name = "Tablet" };
        db.Products.Add(product);
        db.SaveChanges();
    }
