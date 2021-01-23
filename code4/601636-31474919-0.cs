    // using System.Diagnostics;
    // using System.Linq;
	var frames = new StackTrace().GetFrames();
	MethodBase entryMethod = null;
	foreach (var frame in frames)
	{
		var method = frame.GetMethod() as MethodInfo;
		if (method == null)
			continue;
		if (method.Name == "Main" && method.ReturnType == typeof(void))
			entryMethod = method;
	}
	
	if (entryMethod == null)
		entryMethod = frames.Last().GetMethod();
	
	Assembly entryAssembly = entryMethod.Module.Assembly;
