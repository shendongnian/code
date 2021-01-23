    List<Dictionary<string, object>> expandolist = new List<Dictionary<string, object>>();
    foreach (var item in returndata)
      {
      IDictionary<string, object> expando = new ExpandoObject();
      foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(item))
         {
          var obj = propertyDescriptor.GetValue(item);
          expando.Add(propertyDescriptor.Name, obj);
         }
         expandolist.Add(new Dictionary<string, object>(expando));
      }
      return expandolist;
