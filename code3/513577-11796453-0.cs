    public static string GetLastCalledMethod<T>(this Exception ex)
    {
    	var stackTrace = new System.Diagnostics.StackTrace(ex);
    	var lastFrame = stackTrace.GetFrames().FirstOrDefault(frame => frame.GetMethod().DeclaringType.FullName == typeof(T).FullName);
    
    	string methodName = string.Empty;
    	if (lastFrame != null)
    		methodName = lastFrame.GetMethod().Name;
    
    	return methodName;
    }
