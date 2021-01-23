    Type eventType = assembly.GetType(typeName);
    MethodInfo method = typeof(IEventAggregator).GetMethod("GetEvent");
    MethodInfo generic = method.MakeGenericMethod(eventType);
    dynamic subscribeEvent = generic.Invoke(this.eventAggregator, null);
    
    if(subscribeEvent != null)
    {
        subscribeEvent.Subscribe(new Action<object>(GenericEventHandler));
    }
    
    //.... Somewhere else in the class
    
    private void GenericEventHandler(object t)
    {
    }
