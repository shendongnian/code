      public static class PropertySupport
      {       
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
          if (propertyExpression == null)
          {
            throw new ArgumentNullException("propertyExpression");
          }
    
          var memberExpression = propertyExpression.Body as MemberExpression;
          if (memberExpression == null)
          {
            throw new ArgumentException("Invalide Expression", "propertyExpression");
          }
    
          var property = memberExpression.Member as PropertyInfo;
          if (property == null)
          {
            throw new ArgumentException("Pass a property to the function", "propertyExpression");
          }
          return memberExpression.Member.Name;
        }
      }
