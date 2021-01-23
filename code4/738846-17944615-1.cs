    public class GroupKey : IEqualityComparer {
      public string ComponentCode {get;set;}
      public string Key {get;set;}
      bool IEqualityComparer.Equals(object x, object y)
      {
         GroupKey gkx = x as GroupKey;
         GroupKey gky = y as GroupKey;
         return (gkx == null || gky == null) ? false : gkx.ComponentCode == gky.ComponentCode && gkx.Key == gky.Key;
      }
      int IEqualityComparer.GetHashCode(object obj)
      {
         return obj == null ? 0 : obj.GetHashCode();
      }
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
