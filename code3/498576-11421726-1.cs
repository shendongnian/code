    using (var ctx = new MyContext())
    {
        var entityDict = ctx.Entities
            .Where(e => viewModels.Select(v => v.ID).Contains(e.ID))
            .ToDictionary(e => e.ID); // one DB query
        foreach (var viewModel in viewModels)
        {
            Entity entity;
            if (entityDict.TryGetValue(viewModel.ID, out entity))
                entity.Value = viewModel.Value;
        }
        ctx.SaveChanges(); //single transaction with multiple UPDATE statements
    }
