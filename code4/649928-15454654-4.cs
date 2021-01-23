    public void RegisterHandler(object handler)
    {
    	var handled = from iface in handler.GetType().GetInterfaces()
    				  where iface.IsGenericType
    				  where iface.GetGenericTypeDefinition() == typeof(IWorker<>)
    				  select iface.GetGenericArguments()[0];
    
    	foreach (var type in handled)
    	{
    		if (!RegisteredWorkers.ContainsKey(type))
    		{
    			Action<IWorkItem> handleAction = HandlerAction(type, handler);
    			RegisteredWorkers[type] = handleAction;
    		}
    	}   
    }
    
    public void Process(IWorkItem item)
    {
    	Action<IWorkItem> handleAction = RegisteredWorkers[item.GetType()];
    	handleAction(item);
    }
    
    private static Action<IWorkItem> HandlerAction(Type itemType, object handler)
    {
    	var paramExpr = Expression.Parameter(typeof(IWorkItem));
    	var castExpr = Expression.Convert(paramExpr, itemType);
    	MethodInfo processMethod = typeof(IWorker<>).MakeGenericType(itemType).GetMethod("Process");
    	var invokeExpr = Expression.Call(Expression.Constant(handler), processMethod, castExpr);
    
    	var lambda = Expression.Lambda<Action<IWorkItem>>(invokeExpr, paramExpr);
    	return lambda.Compile();
    }
