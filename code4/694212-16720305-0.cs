    string badValue = "hello!";
    const int minSize = 8;
    const int maxSize = 30;
    
    Expression<Func<string, bool>> stringLengthMax = value => value.Length < maxSize;
    Expression<Func<string, bool>> stringLengthMin = value => value.Length > minSize;
    Expression<Func<string, bool>> isEmpty = value => !string.IsNullOrEmpty(value);
    
    ParameterExpression pe = Expression.Parameter(typeof(string));
    
    var x = Expression.Lambda<Func<string, bool>>(
    	Expression.And(Expression.Invoke(stringLengthMax, pe), 
    		Expression.And(Expression.Invoke(stringLengthMin, pe), Expression.Invoke(isEmpty, pe))), pe);
    
    Func<string, bool> shouldValidate = x.Compile();
    bool resultFalse1 = shouldValidate("hello!");
    bool resultFalse2 = shouldValidate("1234567890123456789012345678901");
    //bool resultFalse3 = shouldValidate(null); Throws an exception because you can't do (null).Length
    bool shouldBeTrue = shouldValidate("123456789");
    
    //LinqPad code to view results:
    resultFalse1.Dump();
    resultFalse2.Dump();
    //resultFalse3.Dump();
    shouldBeTrue.Dump();
