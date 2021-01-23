    private static void DumpExpression(Expression expression)
    {
        var sb = new StringBuilder();
        Walk(expression, sb);
        string s = sb.ToString();      
    }
    static object Evaluate(Expression expr)
    {
        switch (expr.NodeType)
        {
            case ExpressionType.Constant:
                return ((ConstantExpression)expr).Value;
            case ExpressionType.MemberAccess:
                var me = (MemberExpression)expr;
                object target = Evaluate(me.Expression);
                switch (me.Member.MemberType)
                {
                    case System.Reflection.MemberTypes.Field:
                        return ((FieldInfo)me.Member).GetValue(target);
                    case System.Reflection.MemberTypes.Property:
                        return ((PropertyInfo)me.Member).GetValue(target, null);
                    default:
                        throw new NotSupportedException(me.Member.MemberType.ToString());
                }
            default:
                throw new NotSupportedException(expr.NodeType.ToString());
        }
    }
    static void Walk(Expression expr, StringBuilder output)
    {
        switch (expr.NodeType)
        {
            case ExpressionType.New:
                var ne = (NewExpression)expr;
                var ctor = ne.Constructor;
                output.Append(" a new ").Append(ctor.DeclaringType.Name);
                if(ne.Arguments != null && ne.Arguments.Count != 0)
                {
                    var parameters = ctor.GetParameters();
                    for(int i = 0 ;i < ne.Arguments.Count ; i++)
                    {
                        output.Append(i == 0 ? " with " : ", ")
                              .Append(parameters[i].Name).Append(" =");
                        Walk(ne.Arguments[i], output);
                    }                    
                }
                break;
            case ExpressionType.Lambda:
                Walk(((LambdaExpression)expr).Body, output);
                break;
            case ExpressionType.Call:
                var mce = (MethodCallExpression)expr;
                if (mce.Method.DeclaringType == typeof(Evaluator))
                {
                    object target = Evaluate(mce.Object);
                    output.Append(" call ").Append(((Evaluator)target).Name);
                }
                else
                {
                    output.Append(" call ").Append(mce.Method.Name);
                }
                if (mce.Object != null)
                {
                    output.Append(" on");
                    Walk(mce.Object, output);
                }
                if (mce.Arguments != null && mce.Arguments.Count != 0)
                {
                    var parameters = mce.Method.GetParameters();
                    for (int i = 0; i < mce.Arguments.Count; i++)
                    {
                        output.Append(i == 0 ? " with " : ", ")
                                .Append(parameters[i].Name).Append(" =");
                        Walk(mce.Arguments[i], output);
                    }
                }
                break;
            case ExpressionType.MemberInit:
                var mei = (MemberInitExpression)expr;
                Walk(mei.NewExpression, output);
                foreach (var member in mei.Bindings)
                {
                    switch(member.BindingType) {
                        case MemberBindingType.Assignment:
                            output.Append(" set ").Append(member.Member.Name)
                                .Append(" to:");
                            Walk(((MemberAssignment)member).Expression, output);
                            break;
                        default:
                            throw new NotSupportedException(member.BindingType.ToString());
                    }
                    
                }
                break;
            case ExpressionType.Constant:
                var ce = (ConstantExpression)expr;
                if (Attribute.IsDefined(ce.Type, typeof(CompilerGeneratedAttribute)))
                {
                    output.Append(" capture-context");
                }
                else
                {
                    output.Append(" ").Append(((ConstantExpression)expr).Value);
                }
                break;
            case ExpressionType.MemberAccess:
                var me = (MemberExpression)expr;
                output.Append(" get ").Append(me.Member.Name).Append(" from");
                if (me.Expression == null)
                { // static
                    output.Append(me.Member.DeclaringType.Name);
                }
                else
                {
                    Walk(me.Expression, output);
                }
                break;
            case ExpressionType.Parameter:
                var pe = (ParameterExpression)expr;
                output.Append(" @").Append(pe.Name);
                break;
            default:
                throw new NotSupportedException(expr.NodeType.ToString());
        }
    }
