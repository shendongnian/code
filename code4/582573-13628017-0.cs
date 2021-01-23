    static void Method2() { }
    
    static void Method1()
    {
    	var sc = SynchronizationContext.Current;
    	sc.Post(delegate { Method2(); }, null);
    }
