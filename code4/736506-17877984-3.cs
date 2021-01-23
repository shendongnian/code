     public int Method<T>(Expression<Func<T, Boolean>> Predicate)
    {
    
    
        var s1 = this.Uow.X.GetAll().Where(Predicate)
                       .SelectMany(a => a.OrganizationalUnits.Where(q => Identity.Y.Contains(q.Z)))
                      .GroupBy(t => t, (k, g) => new
                      {
                          Tag = k,
                          Count = g.Count()
                      })
                      .OrderByDescending(g => g.Count);
    
    
        var s2 = this.Uow.X.GetAll().Where(Predicate)
                        .SelectMany(a => a.Classes.Where(q => Identity.Y.Contains(q.K)))
                        .GroupBy(t => t, (k, g) => new
                        {
                            Tag = k,
                            Count = g.Count()
                        })
                        .OrderByDescending(g => g.Count);
    
    
        var s3 = this.Uow.X.GetAll().Where(Predicate)
                        .SelectMany(a => a.Courses.Where(q => Identity.Y.Contains(q.L)))
                        .GroupBy(t => t, (k, g) => new
                        {
                            Tag = k,
                            Count = g.Count()
                        })
                        .OrderByDescending(g => g.Count);
    
        return s1.Count() + s2.Count() + s3.Count();
    }
