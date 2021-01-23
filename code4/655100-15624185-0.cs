    // Returns a List of expressions that represent the arguments to be passed to the delegate
    static IEnumerable<Expression> getArgExpression(ParameterExpression eventArgs, Type handlerArgType)
    {
        if (eventArgs.Type == typeof(ExampleEventArgs) && handlerArgType == typeof(int))
        {
            //"x1.IntArg"
            var memberInfo = eventArgs.Type.GetMember("IntArg")[0];
            return new List<Expression> { Expression.MakeMemberAccess(eventArgs, memberInfo) };
        }
        if (eventArgs.Type == typeof(MousePositionEventArgs) && handlerArgType == typeof(float))
        {
            //"x1.X"
            var xMemberInfo = eventArgs.Type.GetMember("X")[0];
            //"x1.Y"
            var yMemberInfo = eventArgs.Type.GetMember("Y")[0];
            //"x1.Z"
            var zMemberInfo = eventArgs.Type.GetMember("Z")[0];
            return new List<Expression>
                       {
                           Expression.MakeMemberAccess(eventArgs, xMemberInfo),
                           Expression.MakeMemberAccess(eventArgs, yMemberInfo),
                           Expression.MakeMemberAccess(eventArgs, zMemberInfo),
                       };
        }
        throw new NotSupportedException(eventArgs + "->" + handlerArgType);
    }
