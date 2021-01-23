        public static string[] GetPropertyNameByCustomAttribute
          <ClassToAnalyse, AttributeTypeToFind>
          (
           Func<AttributeTypeToFind, bool> attributePredicate
          )
          where AttributeTypeToFind : Attribute
        {  
          if (attributePredicate == null)
          {
            throw new ArgumentNullException("attributePredicate");
          }
          else
          {
            List<string> propertyNames = new List<string>();
            foreach 
            (
              PropertyInfo propertyInfo in typeof(ClassToAnalyse).GetProperties()
            )
            {
              if
              (
                propertyInfo.GetCustomAttributes
                (
                  typeof(AttributeTypeToFind), true
                ).Any
                (
                  currentAttribute =>                  
                  attributePredicate((AttributeTypeToFind)currentAttribute)
                )
              )
              {
                propertyNames.Add(propertyInfo.Name);
              }
            }  
            return propertyNames.ToArray();
          }
        }
