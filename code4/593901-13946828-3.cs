    static class FooUtils
    {
        public static void Execute<T>(T target, string methodName)
        {
            MethodCache<T>.Execute(target, methodName);
        }
        static class MethodCache<T>
        {
            public static void Execute(T target, string methodName)
            {
                methodCache[methodName](target);
            }
            static readonly Dictionary<string, Action<T>> methodCache;
            static MethodCache()
            {
                methodCache = new Dictionary<string, Action<T>>();
                foreach (var method in typeof(T).GetMethods())
                {
                    if (!method.IsStatic && method.ReturnType == typeof(void)
                        && method.GetParameters().Length == 0)
                    {
                        methodCache.Add(method.Name, (Action<T>)
                            Delegate.CreateDelegate(typeof(Action<T>), method));
                    }
                }
            }
        }
    }
