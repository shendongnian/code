    public class Dispatcher<TTarget,TArgBase>
    {
        private Dictionary<Type, Action<TTarget, TArgBase>> _handlers;
        public Dispatcher(string methodName)
        {
            _handlers = typeof(TTarget).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.Name == methodName)
                .Where(m => m.ReturnType == typeof(void))
                .Where(m => !m.ContainsGenericParameters)
                .Where(m =>
                {
                    var pars = m.GetParameters();
                    return pars.Length == 1 && typeof(TArgBase).IsAssignableFrom(pars[0].ParameterType);
                })
                .ToDictionary(m => m.GetParameters()[0].ParameterType, m => BuildWrapper(m));
        }
        private static Action<TTarget, TArgBase> BuildWrapper(MethodInfo m)
        {
            var target = Expression.Parameter(typeof(TTarget), "target");
            var dest = Expression.Parameter(typeof(TArgBase), "destination");
            var castEvent = Expression.TypeAs(dest, m.GetParameters()[0].ParameterType);
            var call = Expression.Call(target, m, castEvent);
            return Expression.Lambda<Action<TTarget, TArgBase>>(call, target, dest).Compile();
        }
        public bool Call(TTarget target, TArgBase evt)
        {
            Action<TTarget, TArgBase> handler;
            _handlers.TryGetValue(evt.GetType(), out handler);
            if(handler == null)
                return false;
            handler(target, evt);
            return true;
        }
    }
