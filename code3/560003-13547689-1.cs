    class Program
    {
        class MyType
        {
            public MyType(int i)
            {
                this.Value = i;
            }
            public void SetValue(int i)
            {
                this.Value = i;
            }
            public int Value { get; set; }
        }
        public static void Main()
        {
            // You can get this type using a string if you want...
            // I used a fixed type just as an example.
            // The delegate will accept object.
            Type type = typeof(MyType);
            var mi = type.GetMethod("SetValue");
            var obj1 = new MyType(1);
            var obj2 = new MyType(2);
            // If you don't know that the type of the second parameter is int
            // you can use object insted, like this:
            //     BuildDelegate<Action<object, object>>(mi);
            var action = BuildDelegate<Action<object, int>>(mi);
            // If you pass incorrect object type, the generated method conversion
            // will throw an exception... but the program will compile.
            action(obj1, 3);
            action(obj2, 4);
            Console.WriteLine(obj1.Value);
            Console.WriteLine(obj2.Value);
        }
        static T BuildDelegate<T>(MethodInfo method)
        {
            var dgtMi = typeof(T).GetMethod("Invoke");
            var dgtRet = dgtMi.ReturnType;
            var dgtParams = dgtMi.GetParameters();
            var paramsOfDelegate = dgtParams
                .Select(tp => Expression.Parameter(tp.ParameterType, tp.Name))
                .ToArray();
            var methodParams = method.GetParameters();
            if (method.IsStatic)
            {
                var paramsToPass = methodParams
                    .Select((p, i) => CreateParam(paramsOfDelegate, i, p))
                    .ToArray();
                var expr = Expression.Lambda<T>(
                    Expression.Call(method, paramsToPass),
                    paramsOfDelegate);
                return expr.Compile();
            }
            else
            {
                var paramThis = Expression.Convert(paramsOfDelegate[0], method.DeclaringType);
                var paramsToPass = methodParams
                    .Select((p, i) => CreateParam(paramsOfDelegate, i + 1, p))
                    .ToArray();
                var expr = Expression.Lambda<T>(
                    Expression.Call(paramThis, method, paramsToPass),
                    paramsOfDelegate);
                return expr.Compile();
            }
        }
        private static Expression CreateParam(ParameterExpression[] paramsOfDelegate, int i, ParameterInfo callParamType)
        {
            if (i < paramsOfDelegate.Length)
                return Expression.Convert(paramsOfDelegate[i], callParamType.ParameterType);
            if (callParamType.ParameterType.IsValueType)
                return Expression.Constant(Activator.CreateInstance(callParamType.ParameterType));
            return Expression.Constant(null);
        }
    }
