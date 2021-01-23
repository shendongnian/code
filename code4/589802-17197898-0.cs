    public static class TableExtensions
    {
      public static void FillInstance(this Table table, TableRow tableRow, object instance) {
        var propertyInfos = instance.GetType().GetProperties();
        table.Header.Each(header => Assert.IsTrue(propertyInfos.Any(pi => pi.Name == header), "Expected to find the property [{0}] on the object of type [{1}]".FormatWith(header, instance.GetType().Name)));
        var headerProperties = table.Header.Select(header => propertyInfos.Single(p => p.Name == header)).ToList();
        foreach (var propertyInfo in headerProperties) {
          object propertyValue = tableRow[propertyInfo.Name];
          var propertyType = propertyInfo.PropertyType;
          if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) {
            propertyType = propertyType.GetGenericArguments().Single();
          }
  
          var parse = propertyType.GetMethod("Parse", new[] { typeof(string) });
          if (parse != null) {
            // ReSharper disable RedundantExplicitArrayCreation
            try {
              propertyValue = propertyType.Name.Equals("DateTime") ? GeneralTransformations.TranslateDateTimeFrom(propertyValue.ToString()) : parse.Invoke(null, new object[] { propertyValue });
            } catch (Exception ex) {
              var message = "{0}\r\nCould not parse value: {2}.{3}(\"{1}\")".FormatWith(ex.Message, propertyValue, parse.ReturnType.FullName, parse.Name);
              throw new Exception(message, ex);
            }
            // ReSharper restore RedundantExplicitArrayCreation
          }
  
          propertyInfo.SetValue(instance, propertyValue, null);
        }
      }
    }
