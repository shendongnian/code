    class Program
    {
        static Expression<Func<T, bool>> Transform<T>(Expression<Func<T>> expression)
        {
            var initExpression = expression.Body as MemberInitExpression;
            if (initExpression == null)
            {
                throw new ArgumentException();
            }
            Expression bodyExpression = Expression.Constant(true);
            IEnumerable<MemberBinding> bindings = initExpression.Bindings;
            ParameterExpression param = Expression.Parameter(typeof(T));
            foreach (var memberBinding in bindings)
            {
                var memberAssigment = memberBinding as MemberAssignment;
                if (memberAssigment == null)
                {
                    throw new ArgumentException();
                }
                var member = memberAssigment.Member;
                var value = memberAssigment.Expression;
                bodyExpression = Expression.AndAlso(
                    bodyExpression,
                    Expression.Equal(
                        Expression.MakeMemberAccess(param, member),
                        value
                    )
                );
            }
            return Expression.Lambda<Func<T, bool>>(bodyExpression, param);
        }
        static void Main(string[] args)
        {
            Expression<Func<MyClass>> exp = () => new MyClass { Prop1 = 1, Prop3 = 3 };
            var result = Transform(exp);
            var lambda = result.Compile();
            var array = new[]
            {
                new MyClass { Prop1 = 1, Prop3 = 3 },
                new MyClass { Prop1 = 1, Prop2 = 2, Prop3 = 3 },
                new MyClass { Prop1 = 1, Prop3 = 1 },
                new MyClass { Prop1 = 3, Prop3 = 3 },
                new MyClass { Prop1 = 3, Prop3 = 1 },
                new MyClass()
            };
            foreach (var o in array)
            {
                Console.WriteLine(lambda(o));
            }
        }
    }
