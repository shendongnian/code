    var exp = 
        System.Linq.Expressions.Expression.PropertyOrField(
            System.Linq.Expressions.Expression.Constant(foo), 
            "SomeEvent");
    var member = exp.Member;
    var rtMember = (member as FieldInfo).GetValue(foo) as EventHandler;
