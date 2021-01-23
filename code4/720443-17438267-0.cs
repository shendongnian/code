      var sortOrder = "OrderByDescending";
      var sortColumn = "Code";
      if(sortOrder =="OrderByDescending")
         query = query.OrderByDescending(a => GetPropertyValue(a,sortColumn));
      else 
         query = query.OrderBy(a => GetPropertyValue(a,sortColumn));
    private static object GetPropertyValue(object obj, string property)  
    {  
        System.Reflection.PropertyInfo propertyInfo=obj.GetType().GetProperty(property);  
        return propertyInfo.GetValue(obj, null);  
    }  
