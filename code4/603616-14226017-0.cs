    public static object Evaluate(Expression e)
    {
        //A little optimization for constant expressions
        if (e.NodeType == ExpressionType.Constant)
            return ((ConstantExpression)e).Value;
        return Expression.Lambda(e).Compile().DynamicInvoke();
    }
