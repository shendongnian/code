    public static void Call(this Action action)
    {
    	var safeAction = Interlocked.CompareExchange(ref action, null, null);
    	if (safeAction != null)
    		safeAction();
    }
