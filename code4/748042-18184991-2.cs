    BlockExpression MakeSomeAssignments(ParameterExpression obj, Expression value1, int value2)
    {
        var prop1e = Expression.PropertyOrField(obj, "MyProp1");
        var member1e = Expression.Assign(prop1e, value1e);
        var prop2e = Expression.PropertyOrField(obj, "MyProp2");
        var value2e = Expression.Constant(value2);
        var member2e = Expression.Assign(prop2e, value2e);
        
        return new Expression.Block(member1e, member2e);
    }
