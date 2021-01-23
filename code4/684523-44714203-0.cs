      public static T DynamicCast<T>(this object value)
        {
            return (T) value;
        }
        public static object GetPropertyValue<T>(this PropertyInfo propertyInfo, T objectInstance)
        {
            if (typeof(T) != propertyInfo.DeclaringType)
            {
                throw new ArgumentException();
            }
            var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
            var property = Expression.Property(instance, propertyInfo);
            var convert = Expression.TypeAs(property, propertyInfo.PropertyType);
            var lambda =  Expression.Lambda(convert, instance).Compile();
            var result = lambda.DynamicInvoke(objectInstance);
          
            return result;
        }
        public static void SetPropertyValue<T, TP>(this PropertyInfo propertyInfo, T objectInstance, TP value)
            where T : class
            where TP : class
        {
            if (typeof(T) != propertyInfo.DeclaringType)
            {
                throw new ArgumentException();
            }
            var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
            var argument = Expression.Parameter(propertyInfo.PropertyType, "a");
            var setterCall = Expression.Call(
                instance,
                propertyInfo.GetSetMethod(),
                Expression.Convert(argument, propertyInfo.PropertyType));
            var lambda = Expression.Lambda(setterCall, instance, argument).Compile();
            lambda.DynamicInvoke(objectInstance, value);
        }
