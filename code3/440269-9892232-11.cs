    private static void Main(string[] args)
    {
        ParameterExpression CS$0$0001;
        CTX ctx = new CTX();
        Expression<Func<Customer, bool>> expression = 
        Expression.Lambda<Func<Customer, bool>>(
        Expression.Call(null, (MethodInfo) methodof(Enumerable.Any),
        new Expression[] { 
        Expression.Constant(ctx.Invoice), 
        Expression.Lambda<Func<Customer, bool>>(
        Expression.Equal(Expression.Field(CS$0$0001 = 
        Expression.Parameter(typeof(Customer), "customer"), fieldof(Customer.customerId)), 
        Expression.Field(CS$0$0000 = 
        Expression.Parameter(typeof(Customer), "c"), 
        fieldof(Customer.id))), new ParameterExpression[] { CS$0$0001 }) }),
        new ParameterExpression[] { CS$0$0000 });
    }
