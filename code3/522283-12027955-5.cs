    [ScriptableMember]
    public void exec(string compName, string action, ScriptObject scriptObject)
    {
        String compFQName;
        Type compClass; 
        object comp;    
    
        compFQName = "fully.qualified.name." + compName;
    
        compClass = Type.GetType(compFQName);
    
        if (compClass != null) {
            comp = Activator.CreateInstance(compClass);
    
            FieldInfo fieldInfo = compClass.GetField("dispatches", BindingFlags.Static | BindingFlags.Public);
            object[] dispatches = (object[])fieldInfo.GetValue(comp);
    
            if (dispatches != null) {
                foreach (string eventName in dispatches) {
                    EventInfo eventInfo = compClass.GetEvent(eventName);
                    EventHandler handlerMethod = OnComponentEvent;
                    var handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, handlerMethod.Target, handlerMethod.Method);
                    eventInfo.AddEventHandler(comp, handler);
                }                       
            }
        }
    
        // ...
    }
