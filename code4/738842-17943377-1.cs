    return 
    uow.GetRepository<SomeProjection>()
       .GroupBy(x => x.Key)
       .ToDictionary(x => x.Key, 
                     x =>
                     x.GroupBy(y => y.ComponentCode)
                      .ToDictionary(z => z.Key,
                                    z =>
                                    z.Select(z => new EditableSomeProjection
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
