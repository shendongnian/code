    public class Component
    {
        public ComponentPart SomeComponentPart1 { get; private set; }
        public ComponentPart SomeComponentPart2 { get; private set; }
        public Component()
        {
            SomeComponentPart1 = new ComponentPart(this);
            SomeComponentPart2 = new ComponentPart(this);
        }
        public bool IsMethodCallAcceptable(MethodCallExpression method, object[] parameters)
        {
            // collect needed information about caller
            var caller = (method.Object as ConstantExpression).Value;
            var methodName = method.Method.Name;
            var paramsArray = new Dictionary<string, object>();
            for (int i = 0; i < method.Arguments.Count; i++)
                paramsArray.Add((method.Arguments[i] as MemberExpression).Member.Name, parameters[i]);
            // make corresponding decisions
            if (caller == SomeComponentPart2)
                if (methodName == "SomeMethod")
                    if ((int) paramsArray["intArg"] == 0 || (string) paramsArray["stringArg"] == "")
                        return false;
            return true;
        }
    }
    public class ComponentPart
    {
        private Component Owner { get; set; }
        public ComponentPart(Component owner)
        {
            Owner = owner;
        }
        public int SomeMethod(int intArg, string stringArg)
        {
            // check if the method call with provided parameters is acceptable
            Expression<Func<int, string, int>> expr = (i, s) => SomeMethod(intArg, stringArg);
            if (!Owner.IsMethodCallAcceptable(expr.Body as MethodCallExpression, new object[] { intArg, stringArg }))
                throw new Exception();
            // do some work
            return stringArg.Length + intArg;
        }
        public void AnotherMethod(bool boolArg, Dictionary<Guid, DateTime> crazyArg, string stringArg, object objectArg)
        {
            // check if the method call with provided parameters is acceptable
            Expression<Action<bool, Dictionary<Guid, DateTime>, string, object>> expr =
                (b, times, arg3, arg4) => AnotherMethod(boolArg, crazyArg, stringArg, objectArg);
            if (!Owner.IsMethodCallAcceptable(expr.Body as MethodCallExpression, new [] { boolArg, crazyArg, stringArg, objectArg }))
                throw new Exception();
            // do some work
            var g = new Guid();
            var d = DateTime.UtcNow;
        }
    }
