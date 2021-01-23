public static class ExpressionEx
{
    public static BinaryExpression Assign(Expression left, Expression right)
    {
        var assign = typeof(Assigner&lt;&gt;).MakeGenericType(left.Type).GetMethod("Assign");
        var assignExpr = Expression.Add(left, right, assign);
        return assignExpr;
    }
    private static class Assigner&lt;T&gt;
    {
        public static T Assign(ref T left, T right)
        {
            return (left = right);
        }
    }
}
