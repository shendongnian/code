    // return myAnotherParam.MyProperty;
    var baseType = Expression.Parameter(typeof(Test), "baseType");
    var memberAccess = Expression.MakeMemberAccess(baseType, property);
    
    // private String Foo(MyClass myParam)
    var lambda = Expression.Lambda<Func<Test, string>>(memberAccess, Expression.Parameter(typeof(Test), "baseType"));
