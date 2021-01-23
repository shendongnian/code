        public class Test
    {
        public string Name;
    }
    public class CaseInsensitiveExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            if (insideContains)
            {
                if (node.Type == typeof (String))
                {
                    var methodInfo = typeof (String).GetMethod("ToLower", new Type[] {});
                    var expression = Expression.Call(node, methodInfo);
                    return expression;
                }
            }
            return base.VisitMember(node);
        }
        private Boolean insideContains = false;
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Contains")
            {
                if (insideContains) throw new NotSupportedException();
                insideContains = true;
                var result = base.VisitMethodCall(node);
                insideContains = false;
                return result;
            }
            return base.VisitMethodCall(node);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Expression <Func<Test, bool>> expr = (t) => t.Name.Contains("a");
            var  expr1 = (Expression<Func<Test, bool>>) new CaseInsensitiveExpressionVisitor().Visit(expr);
            var test = new[] {new Test {Name = "A"}};
            var length = test.Where(expr1.Compile()).ToArray().Length;
            Debug.Assert(length == 1);
            Debug.Assert(test.Where(expr.Compile()).ToArray().Length == 0);
        }
    }
