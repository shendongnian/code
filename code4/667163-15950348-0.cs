    public static IEnumerable ChangeType(this IEnumerable self, Type type)
    {
       var converter = TypeDescriptor.GetConverter(type);
       foreach (var obj in self)
       {
           yield return converter.ConvertFrom(obj);
       }
    }
