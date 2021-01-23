    public static bool addCallback(string name, Delegate Callback)
    {
        if (DataProxy == null)
            GetDataProxy();
        EventInfo ei = DataProxy.GetType().GetEvent(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (ei == null)
            return false;
        ei.AddEventHandler(DataProxy, Callback);
        Type handlerType = ei.EventHandlerType;
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
        ConstantExpression eventInfo = System.Linq.Expressions.Expression.Constant(ei, typeof(EventInfo));
        ConstantExpression eventCallback = System.Linq.Expressions.Expression.Constant(Callback, typeof(Delegate));
        ConstantExpression dataProxy = System.Linq.Expressions.Expression.Constant(DataProxy, typeof(MAServiceClient));
        MethodCallExpression call = System.Linq.Expressions.Expression.Call(eventInfo, ei.GetType().GetMethod("RemoveEventHandler"), dataProxy, eventCallback);
        //add to Expression.Body the call, which removes the new Eventhandler itsself
        ei.AddEventHandler(DataProxy, System.Linq.Expressions.Expression.Lambda(ei.EventHandlerType, call, parameters).Compile());
        return true;
    }
