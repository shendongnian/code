    public class KeyGeneratorVisitor : ExpressionVisitor
    {
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return Expression.Parameter(node.Type, node.Type.Name);
        }
    
        protected override Expression VisitMember(MemberExpression node)
        {
            if (CanBeEvaluated(node))
            {
                return Expression.Constant(Evaluate(node));
            }
            else
            {
                return base.VisitMember(node);
            }
        }
    
        private static bool CanBeEvaluated(MemberExpression exp)
        {
            while (exp.Expression.NodeType == ExpressionType.MemberAccess)
            {
                exp = (MemberExpression) exp.Expression;
            }
    
            return (exp.Expression.NodeType == ExpressionType.Constant);
        }
    
        private static object Evaluate(Expression exp)
        {
            if (exp.NodeType == ExpressionType.Constant)
            {
                return ((ConstantExpression) exp).Value;
            }
            else
            {
                MemberExpression mexp = (MemberExpression) exp;
                object value = Evaluate(mexp.Expression);
    
                FieldInfo field = mexp.Member as FieldInfo;
                if (field != null)
                {
                    return field.GetValue(value);
                }
                else
                {
                    PropertyInfo property = (PropertyInfo) mexp.Member;
                    return property.GetValue(value, null);
                }
            }
        }
    }
