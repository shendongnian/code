    static MyClass()
    {
        ParameterExpression CS$0$0000;
        FromMyEntity = Expression.Lambda<Func<MyEntity, MyClass>>(
             Expression.MemberInit(Expression.New((ConstructorInfo)
             methodof(MyClass..ctor), new Expression[0]), new MemberBinding[] {
             Expression.Bind(fieldof(MyClass.dbMyProp), Expression.Property(
             CS$0$0000 = Expression.Parameter(typeof(MyEntity), "e"), (MethodInfo)
             methodof(MyEntity.get_MyProp))) }), new ParameterExpression[] {
             CS$0$0000 });
    }
