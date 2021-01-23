    public class FactorVisitor : ExpressionVisitor
    {
        List<object> factors = new List<object>();
        private FactorVisitor(Expression<Func<int>> expression)
        {
            Visit(expression);
        }
        public static List<object> GetFactors(Expression<Func<int>> expression)
        {
            return new FactorVisitor(expression).factors;
        }
        // Add this method for listing compile-time constant values
        protected override Expression VisitConstant(ConstantExpression node)
        {
            factors.Add(node.Value);
            return node;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            if (CanBeEvaluated(node))
            {
                factors.Add(Evaluate(node));
            }
            return node;
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
