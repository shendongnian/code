    field = value;   //<-- move to here
    if (vmExpression != null)
    {
        LambdaExpression lambda = Expression.Lambda(vmExpression);
        Delegate vmFunc = lambda.Compile();
        object sender = vmFunc.DynamicInvoke();
 
        if( handler != null)
        {
            handler(sender, new PropertyChangedEventArgs(body.Member.Name));
        }
    }
 
    return true;
