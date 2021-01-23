	public static string GetCaller()
	{
		var trace = new StackTrace(2);
		var frame = trace.GetFrame(0);
		var caller = frame.GetMethod();
		var callingClass = caller.DeclaringType.Name;
		var callingMethod = caller.Name;
		return String.Format("Called by {0}.{1}", callingClass, callingMethod);
	}
