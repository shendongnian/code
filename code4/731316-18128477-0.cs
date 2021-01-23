      public static IQueryable<T> Like<T>(this IQueryable<T> source, string propertyName, object value)
      {
          IQueryable<T> returnQuery = null;
          switch (value.GetType().ToString())
          {
              case "System.String":
                  returnQuery = source.Where(LikeLambdaString<T>(propertyName, value.ToString()));
                  break;
              default:
                  returnQuery = source.Where(LikeLambdaDouble<T>(propertyName, Convert.ToDouble(value)));
                  break;        
          }
          return returnQuery;
      }
      public static Expression<Func<T, bool>> LikeLambdaString<T>(string propertyName, string value)
      {
          var linqParam = Expression.Parameter(typeof(T), propertyName);
          var linqProp = GetProperty<T>(linqParam, propertyName);
          var containsFunc = Expression.Call(linqProp,
              typeof(string).GetMethod("Contains"),
              new Expression[] { Expression.Constant(value) });
          return Expression.Lambda<Func<T, bool>>(containsFunc,
                  new ParameterExpression[] { linqParam });
      }
      public static Expression<Func<T, bool>> LikeLambdaDouble<T>(string propertyName, double? value)
      {
          string stringValue = (value == null) ? string.Empty : value.ToString();
          var linqParam = Expression.Parameter(typeof(T), propertyName);
          var linqProp = GetProperty<T>(linqParam, propertyName);
          var stringConvertMethodInfo =
              typeof(SqlFunctions).GetMethod("StringConvert", new Type[] { typeof(double?) });
          var stringContainsMethodInfo =
              typeof(String).GetMethod("Contains");
          return
              Expression.Lambda<Func<T, bool>>(
              Expression.Call(
                  Expression.Call(
                      stringConvertMethodInfo,
                      Expression.Convert(
                          linqProp,
                          typeof(double?))),
                  stringContainsMethodInfo,
                  Expression.Constant(stringValue)),
              linqParam);
      }
      public static MemberExpression GetProperty<T>(ParameterExpression linqParam, string propertyName)
      {
          List<string> propertyNames = propertyName.Split('.').ToList();
          var linqProp = Expression.Property(linqParam, propertyNames[0]);
          for (int i = 1; i < propertyNames.Count(); i++)
          {
              linqProp = Expression.Property(linqProp, propertyNames[i]);
          }
          return linqProp;
      }
