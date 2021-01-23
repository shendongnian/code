    public static IOrderedEnumerable<PropertyInfo> GetSortedProperties<T>()
    {
      return typeof(T)
        .GetProperties()
        .OrderBy(p => ((Order)p.GetCustomAttributes(typeof(Order), false)[0]).Order);
    }
