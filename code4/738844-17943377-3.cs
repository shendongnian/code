    return 
    uow.GetRepository<SomeProjection>()
       .GroupBy(x => x.Key)
       .ToDictionary(g1 => g1.Key, 
                     g1 =>
                     g1.GroupBy(y => y.ComponentCode)
                       .ToDictionary(g2 => g2.Key,
                                     g2 =>
                                     g2.Select(z => new EditableSomeProjection
                                     {
                                        Type = z.Type,
                                        Key = z.Key,
                                        Value = z.Value,
                                        Component = z.ComponentCode,
                                        Culture = z.CultureCode,
                                        Code = z.Code.Key,
                                        Version = z.Version,
                                        Category = z.Category
                                     }).ToList()));
