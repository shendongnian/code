    // helper classes which compiles a fast, type-safe delegate for writing various types
    static class MyBinaryWriterHelper<T> {
        public static readonly Action<MyBinaryWriter, T> WriteAction;
    
        static {
            // find the existing Write(T) on the MyBinaryWriter type
            var writeMethod = typeof(MyBinaryWriter).GetMethods()
                .FirstOrDefault(m => m.Name == "Write" && m.GetArguments().All(p => p.ParameterType == typeof(T));
            // if there is no such method, fail
            if (writeMethod == null) { throw ... }
    
            // build up an expression (writer, t) => writer.Write(t)
            var writerParam = Expression.Parameter(typeof(MyBinaryWriter));
            var tParam = Expression.Parameter(typeof(T));
            var call = Expression.Call(writerParam, writeMethod, tParam);
            var lambda = Expression.Lambda<Action<MyBinaryWriter, T>>(call, new[] { writerParam, tParam });
            // compile the expression to a delegate, caching the result statically in the
            // readonly WriteAction field
            WriteAction = lambda.Compile();
        }
    }
    
    // then in your writer class
    public void Write<T>(IEnumerable<T> collection) {
        foreach (var t in collection) {
            MyBinaryWriterHelper<T>.WriteAction(this, t);
        }
    }
