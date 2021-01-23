    public static byte[] Hash<T>(T entity) 
    {
      var seen = new HashSet<object>();
      var properties = GetAllSimpleProperties(entity, seen);
      return properties.Select(p => BitConverter.GetBytes(p.GetHashCode())).Aggregate((ag, next) => ag.Concat(next)).ToArray();
    }
    private static IEnumerable<object> GetAllSimpleProperties<T>(T entity, HashSet<object> seen)
    {
      foreach (var property in PropertiesOf<T>.All(entity))
      {
        if (property is int || property is long || property is string ...) yield return property;
        else if (seen.Add(property)) // Handle cyclic references
        {
          foreach (var simple in GetSimpleProperties(property, seen)) yield return simple;
        }
      }
    }
    private static class PropertiesOf<T>
    {
      private static readonly List<Func<T, dynamic>> Properties = new List<Func<T, dynamic>>();
      static PropertiesOf()
      {
        foreach (var property in typeof(T).GetProperties())
        {
          var getMethod = property.GetGetMethod();
          var function = (Func<T, dynamic>)Delegate.CreateDelegate(typeof(Func<T, dynamic>), getMethod);
          Properties.Add(function);
        }
      }
      public static IEnumerable<dynamic> All(T entity) 
      {
        return Properties.Select(p => p(entity)).Where(v => v != null);
      }
    } 
