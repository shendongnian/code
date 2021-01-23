    PropertyInfo[] properties = MyClass.GetType().GetProperties();
    foreach (PropertyInfo property in properties)
    {
      if (property.Name == "MyProperty")
      {
       object value = results.GetType().GetProperty(property.Name).GetValue(MyClass, null);
       if (value != null)
       {
         //assign the value
       }
      }
    }
    
