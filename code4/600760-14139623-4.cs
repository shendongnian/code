    static class ConstructorFactory
    {
        static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
        {
            var paramsInfo = ctor.GetParameters();
            var param = Expression.Parameter(typeof(object[]), "args");
            var argsExp = new Expression[paramsInfo.Length];
            for (var i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;
                Expression paramAccessorExp = Expression.ArrayIndex(param, index);
                Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);
                argsExp[i] = paramCastExp;
            }
            var newExp = Expression.New(ctor, argsExp);
            var lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);
            var compiled = (ObjectActivator<T>)lambda.Compile();
            return compiled;
        }
        public static Func<T> Create<T>(Type destType)
        {
            var ctor = destType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).First();
            Func<ConstructorInfo, object> activatorMethod = GetActivator<Type>;
            var method = typeof(ConstructorFactory).GetMethod(activatorMethod.Method.Name, BindingFlags.Static | BindingFlags.NonPublic);
            var generic = method.MakeGenericMethod(destType);
            dynamic activator = generic.Invoke(null, new object[] { ctor });
            return () => activator();
        }
        delegate T ObjectActivator<out T>(params object[] args);
    }
