    public class GroupKey {
      public string ComponentCode {get;set;}
      public string Key {get;set;}
    }
    //.....
    //.....
    return uow.GetRepository<SomeProjection>().GroupBy(x => new GroupKey{ComponentCode=x.ComponentCode, Key=x.Key}).ToDictionary(x => x.Key, y =>
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
