    public class ReflectionHelper
    {
        public static string GetPropertyNameFromExpression<T>(Expression<Func<T>> property) 
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression) 
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            } 
            else 
            {
                memberExpression = (MemberExpression)lambda.Body;
            }
            return memberExpression.Member.Name;
        }
    }
