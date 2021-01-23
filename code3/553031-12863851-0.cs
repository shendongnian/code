    public class Foo
    {
        public string Value { get; set; }
    }
    
    public class ReplaceVisitor<T> : ExpressionVisitor
    {
        private readonly T _instance;
        public ReplaceVisitor(T instance)
        {
            _instance = instance;
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return Expression.Constant(_instance);
        }
    }
    
    class Program
    {
        static void Main()
        {
            Expression<Func<Foo, bool>> predicate = t => t.Value == "SomeValue";
            var foo = new Foo { Value = "SomeValue" };
            Expression<Func<bool>> result = Convert(predicate, foo);
            Console.WriteLine(result.Compile()());
        }
    
        static Expression<Func<bool>> Convert<T>(Expression<Func<T, bool>> expression, T instance)
        {
            return Expression.Lambda<Func<bool>>(
                new ReplaceVisitor<T>(instance).Visit(expression.Body)
            );
        }
    }
