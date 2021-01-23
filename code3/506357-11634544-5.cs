            // Get the current SynchronizationContext on the current thread 
            public static SynchronizationContext Current 
            {
                get
                { 
                    SynchronizationContext context = null;
                    ExecutionContext ec = 
                             Thread.CurrentThread.GetExecutionContextNoCreate(); 
                    if (ec != null) 
                    {
                        context = ec.SynchronizationContext; 
                    }
    
                    // ... Some code excluded ...
                    return context;
                }
            } 
