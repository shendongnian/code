    var q = from p in dbContext.Parents
        where p.Id == 123
        select new ParentViewModel
        {
            Id = p.Id,
            Children = (from c in p.Children
                        select new ChildViewModel()
                        {
                            Id = c.Id,
                            Toys = (from t in c.Toys
                                    select new ToyViewModel() 
                                    {
                                        Id = t.Id,
                                        Name = t.Name
                                    }).ToList()
                        }).ToList()
        };
