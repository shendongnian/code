    using((Model.Entities context = new Model.Entities())
    {
        var options = context.Products
            .Single(p => p.ID == 1)
            .Options
            .ToList();
    }
