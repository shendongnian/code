    public static IQueryable<T> NullableShortBetween<T>(this  IQueryable<T> queryable, short? minValue, short? maxValue) where T: class
            {
                //item (= left part of the lambda)
                var parameterExpression = Expression.Parameter(typeof (T), "item");
                //retrieve all nullable short properties of your entity, to change if you have other criterias to get these "year" properties
                var shortProperties = typeof (T).GetProperties().Where(m => m.CanRead && m.CanWrite && m.PropertyType == typeof(short?));
    
                foreach (var shortProperty in shortProperties)
                {
                    //item (right part of the lambda)
                    Expression memberExpression = parameterExpression;
                    //item.<PropertyName>
                    memberExpression = Expression.Property(memberExpression, shortProperty);
                    //item.<PropertyName>.HasValue
                    Expression firstPart = Expression.Property(memberExpression, "HasValue");
                    //item.<PropertyName> >= minValue
                    Expression secondPart = Expression.GreaterThanOrEqual(memberExpression, Expression.Convert(Expression.Constant(minValue), typeof (short?)));
                    //item.<PropertyName> <= maxValue
                    var thirdPart = Expression.LessThanOrEqual(memberExpression, Expression.Convert(Expression.Constant(maxValue), typeof (short?)));
                    //item.<PropertyName>.HasValue && item.<PropertyName> >= minValue
                    var result = Expression.And(firstPart, secondPart);
                    //item.<PropertyName>.HasValue && item.<PropertyName> >= minValue && item.<PropertyName> <= maxValue
                    result = Expression.AndAlso(result, thirdPart);
                    //pass the predicate to the queryable
                    queryable = queryable.Where(Expression.Lambda<Func<T, bool>>(result, new[] {parameterExpression}));
                }
                return queryable;
            }
