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
          return memberExpression.Member.Name;
        }
      }
