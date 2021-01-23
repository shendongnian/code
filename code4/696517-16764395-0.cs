    public static void Execute<T>(Delegate eventToRaise, object sender, T eventArgs) where T:EventArgs
            {
                if (eventToRaise == null)
                    return;
    
                Delegate[] registeredEventHandlers = eventToRaise.GetInvocationList();
    
                foreach (Delegate eventHandler in registeredEventHandlers)
                {
                    object target = eventHandler.Target; // Need access to the Target property for conditions
    
                    // * Code deciding if should invoke the event handler *
    
                    eventHandler.DynamicInvoke(sender, eventArgs);
                }
            }
