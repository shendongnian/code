    public static void WriteLine(this TraceSource source, object o)
    {
    	var str = (o ?? string.Empty).ToString();
    
    	if (source.Listeners == null || source.Listeners.Count == 0) throw new InvalidOperationException(string.Format("TraceSource named {0} has no listeners", source.Name));
    
    	foreach (TraceListener listener in source.Listeners)
    		listener.WriteLine(str);
    }
