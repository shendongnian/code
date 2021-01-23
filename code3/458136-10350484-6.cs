    class Wrapper
    {
        private readonly Dictionary<string, MemberExpression> _registrations = 
            new Dictionary<string, MemberExpression>();
        public void Register<T>(string name, Expression<Func<T>> expr)
        {
            _registrations[name] = (MemberExpression)expr.Body;
        }
        public object GetValue(string name)
        {
            var expr = _registrations[name];
            var fieldInfo = (FieldInfo)expr.Member;
            var obj = ((ConstantExpression)expr.Expression).Value;
            return fieldInfo.GetValue(obj);
        }
    }
    private static void Main(string[] args)
    {
        var wrapper = new Wrapper();
        int x = 0;
        storage.Register("x", () => x);
        Console.WriteLine(wrapper.GetValue("x")); //0
        x = 1;
        Console.WriteLine(wrapper.GetValue("x")); //1
    }
