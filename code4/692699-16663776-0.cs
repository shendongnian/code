    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    static class Program {
        static void Main() {
            Expression<Func<int, float, double>> exp = (i, f) => i * f;
            var func = CompileToBasicType(exp);
    
            object[] args = { 3, 2.3F };
            object result = func(args); // 6.9 (double)
        }
    
        static Func<object[], object> CompileToBasicType(LambdaExpression exp) {
            ParameterExpression arg =
                Expression.Parameter(typeof(object[]), "args");
            Dictionary<Expression, Expression> lookup =
                new Dictionary<Expression, Expression>();
            int i = 0;
            foreach (var p in exp.Parameters) {
                lookup.Add(p, Expression.Convert(Expression.ArrayIndex(
                    arg, Expression.Constant(i++)), p.Type));
            }
            var body = Expression.Convert(
                new ReplaceVisitor(lookup).Visit(exp.Body), typeof(object));
            return Expression.Lambda<Func<object[], object>>(body, arg).Compile();
        }
        class ReplaceVisitor : ExpressionVisitor {
            private readonly Dictionary<Expression, Expression> lookup;
            public ReplaceVisitor(Dictionary<Expression, Expression> lookup) {
                if (lookup == null) throw new ArgumentNullException("lookup");
                this.lookup= lookup;
            }
            public override Expression Visit(Expression node) {
                Expression found;
                return lookup.TryGetValue(node, out found) ? found
                    : base.Visit(node);
            }
        }
    }
