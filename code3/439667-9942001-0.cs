    using ex = System.Linq.Expressions;
    using System.Linq.Expressions;
        public static bool addCallback(string name, Delegate Callback)
        {
            if (DataProxy == null)
                GetDataProxy();
            EventInfo ei = DataProxy.GetType().GetEvent(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (ei == null)
                return false;
            ei.AddEventHandler(DataProxy, Callback);
            Type handlerType = ei.EventHandlerType;
            MethodInfo removeMethod = ei.GetType().GetMethod("RemoveEventHandler");
            MethodInfo invokeMethod = handlerType.GetMethod("Invoke");
            ParameterInfo[] parms = invokeMethod.GetParameters();
            Type[] parmTypes = new Type[parms.Length];
            for (int i = 0; i < parms.Length; i++)
            {
                parmTypes[i] = parms[i].ParameterType;
            }
            List<ParameterExpression> parameters = new List<ParameterExpression>();
            foreach(Type t in parmTypes)
            {
                parameters.Add(System.Linq.Expressions.Expression.Parameter(t));
            }
            Delegate self = null;
            Func<Delegate> getSelf = () => self;
            ConstantExpression eventInfo = ex.Expression.Constant(ei, typeof(EventInfo));
            ConstantExpression eventCallback = ex.Expression.Constant(Callback, typeof(Delegate));
            ConstantExpression dataProxy = ex.Expression.Constant(DataProxy, typeof(MAServiceClient));
            MethodCallExpression removeCallback = ex.Expression.Call(eventInfo, removeMethod, dataProxy, eventCallback);
            MethodCallExpression removeSelf = ex.Expression.Call(eventInfo, removeMethod, dataProxy, ex.Expression.Invoke(ex.Expression.Constant(getSelf)));
            BlockExpression block = ex.Expression.Block(removeCallback, removeSelf);
            LambdaExpression lambda = ex.Expression.Lambda(ei.EventHandlerType, block, parameters);
            Delegate del = lambda.Compile();
            self = del;
            ei.AddEventHandler(DataProxy, del);
            lambda = ex.Expression.Lambda(ei.EventHandlerType, block, parameters);
            return true;
        }
