     public static List<string> GetModelNames(this DbContext context ) {
          var model = new List<string>();
          var propList = context.GetType().GetProperties();
          foreach (var propertyInfo in propList)
          {
          if (propertyInfo.PropertyType.GetTypeInfo().Name.StartsWith("DbSet"))
          {
              model.Add(propertyInfo.Name);
              var innerProps = propertyInfo.GetType().GetProperties(); // added to snoop around in debug mode , can your find anything useful?
          }
          }
          return model;
      }
     public static List<string> GetModelTypes(this DbContext context)
     {
         var model = new List<string>();
         var propList = context.GetType().GetProperties();
         foreach (var propertyInfo in propList)
         {
             if (propertyInfo.PropertyType.GetTypeInfo().Name.StartsWith("DbSet"   ))
             {
                 model.Add(propertyInfo.PropertyType.GenericTypeArguments[0].Name);
             }
         }
         return model;
     }
    }   
