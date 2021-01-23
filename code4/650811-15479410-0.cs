    public static string LambdaToString<T>(Expression<Func<T, bool>> expression)
        {
            BinaryExpression binaryExpression = expression.Body as BinaryExpression;
            Expression right = binaryExpression.Right;//right part of the "==" of your predicate
            var objectMember = Expression.Convert(right, typeof(object));//convert to object, as we don't know what's in
    
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
    
            var getter = getterLambda.Compile();
    
            var valueYouWant = getter();//here's the "x" or "y"
            //...
