    internal static class Program
    {
        static void Main()
        {
        
            Expression<Func<Model, Foo>> expression1 = m => m.SubModel.Foo;
            Expression<Func<Foo, string>> expression2 = f => f.Bar.Value;
    
            var swap = new SwapVisitor(expression2.Parameters[0], expression1.Body);
            var lambda = Expression.Lambda<Func<Model, string>>(
                   swap.Visit(expression2.Body), expression1.Parameters);
            // test it worked
            var func = lambda.Compile();
            Model test = new Model {SubModel = new SubModel {Foo = new Foo {
                 Bar = new Bar { Value = "abc"}}}};
            Console.WriteLine(func(test)); // "abc"
        }
    }
    class SwapVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
     	     return node == from ? to : base.Visit(node);
        }
    }
