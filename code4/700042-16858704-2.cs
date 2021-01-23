    const string exp = "variable > 30";
    var p = Expression.Parameter(typeof(int), "variable");
    var e = DynamicExpression.ParseLambda(new[] { p }, null, exp);
    
   
    bool a = (bool)e.Compile().DynamicInvoke(20);
    bool b = (bool)e.Compile().DynamicInvoke(40);
