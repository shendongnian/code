    public static class ExpressionExtensions
    {
        /// <summary>
        ///     create expression by property name
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="propertyName">
        ///     <example>Urer.Role.Name</example>
        /// </param>
        /// <returns></returns>
        public static Expression<Func<TModel, dynamic>> CreateExpression<TModel>(this string propertyName) {
            Type currentType = typeof (TModel);
            ParameterExpression parameter = Expression.Parameter(currentType, "x");
            Expression expression = parameter;
            int i = 0;
            List<string> propertyChain = propertyName.Split('.').ToList();
            do {
                System.Reflection.PropertyInfo propertyInfo = currentType.GetProperty(propertyChain[i]);
                currentType = propertyInfo.PropertyType;
                if (currentType.Namespace == "System") {
                    currentType = typeof (object);
                }
                expression = Expression.Convert(Expression.PropertyOrField(expression, propertyInfo.Name), currentType);
                i++;
            } while (propertyChain.Count > i);
            return Expression.Lambda<Func<TModel, dynamic>>(expression, parameter);
        }
    }
