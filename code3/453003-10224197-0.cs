    public class HelperClass<T>
    {
        public static void Property<TProp>(Expression<Func<T, TProp>> expression)
        {
            var body = expression.Body as MemberExpression;
    
            if (body == null)
            {
                throw new ArgumentException("'expression' should be a member expression");
            }
    
            var propertyInfo = (PropertyInfo)body.Member;
    
            var propertyType = propertyInfo.PropertyType;
            var propertyName = propertyInfo.Name;
        }
    }
