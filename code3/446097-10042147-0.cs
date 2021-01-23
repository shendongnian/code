    using(context = new MyDataContextClass())
    {
      return (from p in Context.Categories
              let relatedchilds = (from c in Context.SubCategories
                                   where c.CategoryId == p.Id
                                   select c).Take(5)
              select new ParentChild
              {
                Parent = p,
                Childs = relatedchilds
              }).ToList();
    }
