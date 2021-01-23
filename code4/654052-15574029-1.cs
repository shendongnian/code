    using (MyContext container = new myContext())
    {
        var result = container
            .Sales
            .Include("Products")
            .Where(s => s.Id == id)
            .FirstOrDefault();
        result.Products.ToList();
        return result;
    }
