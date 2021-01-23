      object value = GetValue();
      string propertyName = "MyProperty";
      var parameter = Expression.Parameter(typeof(object));
      var cast = Expression.Convert(parameter, value.GetType());
      var propertyGetter = Expression.Property(cast, propertyName);
      var castResult = Expression.Convert(propertyGetter, typeof(object));//for boxing
      var propertyRetriver = Expression.Lambda<Func<object, object>>(castResult, parameter).Compile();
     var retrivedPropertyValue = propertyRetriver(value);
