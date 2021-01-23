    try
	{
	    //Do something
	}
	catch (Exception ex)
	{
		System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
		Console.WriteLine("Line: " + trace.GetFrame(0).GetFileLineNumber());
	}
