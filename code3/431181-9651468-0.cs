    private static void recurseAndFindProperty(Object obj) {
       foreach (PropertyInfo pi in obj.GetType().GetProperties()) {
           if ((pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(EntityCollection<>))) {
               IEnumerable collection = (IEnumerable)pi.GetValue(obj, null);
    
               foreach (object val in collection)
                   recurseAndFindProperty(val);
           } else {
                if (pi.PropertyType != typeof(Descendant))
                    if ((int)pi.GetValue(obj, null) == 1231241)
                        pi.SetValue(obj, 10, null)); // Change the value.
           }
       }
    }
