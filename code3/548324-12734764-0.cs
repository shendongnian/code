    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    static class Program
    {
        static void Main()
        {
            var t1 = DateTimeOffset.Parse("10/1/2012");
    
            int? n1 = 1;
    
            Expression<Func<Sample, bool>> x1 = ud =>
                (ud.Date == t1 && ud.Number == n1);
    
            var sanitized = (Expression<Func<Sample, bool>>)
                new Literalizer().Visit(x1);
    
            Console.WriteLine(sanitized.ToString());
        }
    }
    
    class Literalizer : ExpressionVisitor
    {
        protected override Expression VisitMember(MemberExpression node)
        {
            if(node.Member.DeclaringType.IsDefined(typeof(CompilerGeneratedAttribute), false)
                && node.Expression.NodeType == ExpressionType.Constant)
            {
                object target = ((ConstantExpression)node.Expression).Value, value;
                switch (node.Member.MemberType)
                {
                    case MemberTypes.Property:
                        value = ((PropertyInfo)node.Member).GetValue(target, null);
                        break;
                    case MemberTypes.Field:
                        value = ((FieldInfo)node.Member).GetValue(target);
                        break;
                    default:
                        value = target = null;
                        break;
                }
                if (target != null) return Expression.Constant(value, node.Type);
            }
            return base.VisitMember(node);
        }
    }
    
    class Sample
    {
        public int? Number{set;get;}
        public DateTimeOffset Date{set;get;}
    }
