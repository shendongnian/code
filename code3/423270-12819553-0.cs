    var items = new[]
                {
                    new { Id = Guid.Empty },
                    new { Id = Guid.NewGuid() },
                    new { Id = Guid.NewGuid() }
                };
    var result = items.AsQueryable()
        .Where("Id.Equals(@0)", Guid.Empty)
        .Any();
