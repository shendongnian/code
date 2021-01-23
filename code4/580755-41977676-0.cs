    public static string GetPropertyDisplayName(object descriptor)
    {
       var propertyDescriptor = descriptor as PropertyDescriptor;
       if (propertyDescriptor != null)
       {
          var displayName = propertyDescriptor.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
          if (displayName != null && !Equals(displayName, DisplayNameAttribute.Default))
          {
             return displayName.DisplayName;
          }
       }
       else
       {
          var propertyInfo = descriptor as PropertyInfo;
          if (propertyInfo != null)
          {
             var attributes = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), true);
             foreach (object attribute in attributes)
             {
                var displayName = attribute as DisplayNameAttribute;
                if (displayName != null && !Equals(displayName, DisplayNameAttribute.Default))
                {
                   return displayName.DisplayName;
                }
             }
          }
       }
       return null;
    }
