    select new ParentViewModel
    {
       Id = p.Id,
       Children = p.Children.Select(c => new ChildViewModel {
           Id = c.Id,
           Toys = c.Toys.Select(t => new ToyViewModel { ... }).ToList()
       }).ToList()
    };
