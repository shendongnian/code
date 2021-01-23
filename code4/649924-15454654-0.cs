    private static Dictionary<Type, object> RegisteredWorkers = new Dictionary<Type, object>();
    
    public static void RegisterWorker(object worker)
    {
    	var handled = from iface in worker.GetType().GetInterfaces()
    				  where iface.IsGenericType
    				  where iface.GetGenericTypeDefinition() == typeof(Worker<>)
    				  select iface.GetGenericArguments()[0];
    	foreach (var type in handled)
    		if (!RegisteredWorkers.ContainsKey(type))
    			RegisteredWorkers[type] = worker;
    }
    
    public static void ProcessWorkItem(WorkItem item)
    {
    	object handler = RegisteredWorkers[item.getType()];
    	Type workerType = typeof(Worker<>).MakeGenericType(item.GetType());
    	MethodInfo processMethod = workerType.GetMethod("Process");
    	processMethod.Invoke(handler, new object[] { item });
    }
