    class Bar {
    
      public String Foo { get; set; }
    
      public Boolean Cmp(String propertyName, String value) {
        var propertyInfo = GetType()
          .GetProperties()
          .SingleOrDefault(pi =>
            pi.CanRead
            && pi.PropertyType == typeof(String)
            && pi.Name == propertyName
          );
        if (propertyInfo == null)
          return false;
        var propertyValue = (String) propertyInfo.GetValue(this);
        return propertyValue == value;
      }
    
    }
