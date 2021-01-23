    public static Type[] GetNonSystemTypes<T>()
    {
      var systemTypes = typeof(T).GetProperties().Select(t => t.PropertyType).Where(t => t.Namespace == "System");
      return typeof(T).GetProperties().Select(t => t.PropertyType).Except(systemTypes).ToArray();
    }
