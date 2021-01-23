    var methodInfo = typeof(C).GetMethod("M", new Type[] { typeof(Type), typeof(int[]) });
    //I have other overloads for M, hence I need to specify the type of arugments
    
    var typeArgumentExp = Expression.Parameter(someType);
    
    //this is the first argument to method M, not sure if I have chosen the right
    //expression
    
    var intArrayArgumentExp = Expression.NewArrayInit(typeof(int), Enumerable.Repeat(Expression.Constant(0), 3));
    
    var combinedArgumentsExp = new Expression[] { typeArgumentExp }.Concat(intArrayArgumentExp);
    var call = Expression.Call(methodInfo, combinedArgumentsExp);
