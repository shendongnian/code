    return 
    uow.GetRepository<SomeProjection>()
       .GroupBy(x => x.Key)
       .ToDictionary(x => x.Key, 
                     y =>
                     y.Select(z => new EditableSomeProjection
                        {
                            Type = z.Type,
                            Key = z.Key,
                            Value = z.Value,
                            Component = z.ComponentCode,
                            Culture = z.CultureCode,
                            Code = z.Code.Key,
                            Version = z.Version,
                            Category = z.Category
                        }).ToList());
