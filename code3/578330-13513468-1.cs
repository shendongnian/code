    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    class Source {
        public List<Value> Values {get;set;}
    }
    class Value {
        public int FinalValue {get;set;}
    }
    static class Program {
        static void Main() {
            Expression<Func<Source, IEnumerable<Value>>> f1 =
                source => source.Values;
            Expression<Func<IEnumerable<Value>, bool>> f2 =
                vals => vals.Any(v => v.FinalValue == 3);
    
            // change the p0 from f2 => f1
            var body = SwapVisitor.Swap(f2.Body, f2.Parameters[0], f1.Body);
            var lambda = Expression.Lambda<Func<Source, bool>>(body,f1.Parameters);
            // which is:
            // source => source.Values.Any(v => (v.FinalValue == 3))
        }
        
    }
    class SwapVisitor : ExpressionVisitor {
        private readonly Expression from, to;
        private SwapVisitor(Expression from, Expression to) {
            this.from = from;
            this.to = to;
        }
        public static Expression Swap(Expression body,
            Expression from, Expression to)
        {
            return new SwapVisitor(from, to).Visit(body);
        }
        public override Expression Visit(Expression node)
        {
     	     return node == from ? to : base.Visit(node);
        }
    }
