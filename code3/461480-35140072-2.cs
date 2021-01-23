    static string GetDataMemberName(string colName, object t) {
      foreach(PropertyInfo propertyInfo in t.GetType().GetProperties()) {
        if (propertyInfo.CanRead) {
          if (propertyInfo.Name == colName) {
            var attributes = propertyInfo.GetCustomAttributes(typeof(DataMemberAttribute), false).FirstOrDefault() as DataMemberAttribute;
            if (attributes != null && !string.IsNullOrEmpty(attributes.Name))
              return attributes.Name;
            return colName;
          }
        }
      }
      return colName;
    }
