    interface IDependOn<T> { }
    
    class Oil { }
    
    class Seat { }
    
    class Wheel : IDependOn<Oil> { }
    
    class Car : IDependOn<Wheel>, IDependOn<Oil> { }
    
    static class TypeExtensions {
    
      public static IEnumerable<Type> OrderByDependencies(this IEnumerable<Type> types) {
        if (types == null)
          throw new ArgumentNullException("types");
        var dictionary = types.ToDictionary(t => t, t => GetDependOnTypes(t));
        var list = dictionary
          .Where(kvp => !kvp.Value.Any())
          .Select(kvp => kvp.Key)
          .ToList();
        foreach (var type in list)
          dictionary.Remove(type);
        foreach (var keyValuePair in dictionary.Where(kvp => !kvp.Value.Any())) {
          list.Add(keyValuePair.Key);
          dictionary.Remove(keyValuePair.Key);
        }
        while (dictionary.Count > 0) {
          var type = dictionary.Keys.First();
          Recurse(type, dictionary, list);
        }
        return list;
      }
      static void Recurse(Type type, Dictionary<Type, IEnumerable<Type>> dictionary, List<Type> list) {
        if (!dictionary.ContainsKey(type))
          return;
        foreach (var dependOnType in dictionary[type])
          Recurse(dependOnType, dictionary, list);
        list.Add(type);
        dictionary.Remove(type);
      }
    
      static IEnumerable<Type> GetDependOnTypes(Type type) {
        return type
          .GetInterfaces()
          .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDependOn<>))
          .Select(i => i.GetGenericArguments().First());
      }
    
    }
