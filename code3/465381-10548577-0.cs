    var q = from p in dbContext.Parents
        where p.Id = 123
        select new ParentViewModel
        {
           Id = p.Id,
           Children = p.Children.Select(c => new ChildViewModel
           {
               Id = c.Id,
               Toys = c.Toys.Select(t => new ToysViewModel
               {
                   Id = t.Id
               }).ToList()
           }).ToList()
        };
