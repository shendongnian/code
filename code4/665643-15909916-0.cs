    public class MyVisitor : IVisitor
    {
        readonly SomeDefaultdeVisitor _defaultVisitor;
        public MyVisitor()
        {
            _defaultVisitor = new SomeDefaultdeVisitor();
        }
        public RetVal Visit(Expression e)
        {
            return _defaultVisitor.Visit(e);
        }
        // ...
        // implement your own for one 'route'
    }
