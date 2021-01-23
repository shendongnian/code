    private IDictionary<Type, Func<Entity, string, object>> actions;
    
    private void InitActions()
    {
    	actions = new Dictionary<Type, Func<Entity, string, object>>
    		{
    			{
    				typeof (string), (entity, attribute) =>
    					{
    						// this could be your custom code for string
    						return entity[attribute];
    					}
    			},
    			{
    				typeof (int), (entity, attribute) =>
    					{
    						// this could be your custom code for int
    						return entity[attribute];
    					}
    			}
    		};
    }
    
    private T GetIntValue<T>(Entity entity, String attribute, T substitute = default(T))
    {
    	if (entity.Contains(attribute) && actions.ContainsKey(typeof (T)))
    	{
    		Func<Entity, string, object> action = actions[typeof (T)];
    		return (T)action(entity, attribute);
    	}
    	return substitute;
    }
