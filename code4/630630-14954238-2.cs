    // ...
    public class Typelist<T1, T2> : ITypelist
    {
        public Type MakeGenericType(Type t)
        {
            return t.MakeGenericType(typeof(T1));
        }
        public MethodInfo MakeGenericMethod(MethodInfo method)
        {
            return method.MakeGenericMethod(typeof(T1));
        }
        public Type Head { get { return typeof(T1); } }
        public Typelist<T2> Tail { get { return new Typelist<T2>(); } }
        public Type[] List { get { return new Type[] { typeof(T1), typeof(T2) }; } }
    }
    // ...
    public static class Ext
    {
        public static void InvokeAll<T1>(this Typelist<T1> typelist, MethodInfo baseMethod, object obj, object[] pars)
        {
            typelist.MakeGenericMethod(baseMethod).Invoke(obj, pars);
            // tail so no recursion
        }
        public static void InvokeAll<T1, T2>(this Typelist<T1, T2> typelist, MethodInfo baseMethod, object obj, object[] pars)
        {
            typelist.MakeGenericMethod(baseMethod).Invoke(obj, pars);
            InvokeAll(typelist.Tail, baseMethod, obj, pars);
        }
    }
