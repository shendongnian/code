    ctx.Categories
      .Where(c => c.ID == 3)
      .Select(c => new Category()
        {
          Name = c.Name,
          Suppliers = c.Suppliers.Select(s => new Supplier()
            {
              Name = s.Name,
              Timestamp = s.Timestamp
            })
        })
