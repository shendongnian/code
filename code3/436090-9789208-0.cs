    try
    {
        double d = 1 / 0;
    }
    catch (Exception ex)
    {
        var trace = new System.Diagnostics.StackTrace();
        var frame = trace.GetFrame(1);
        var methodName = frame.GetMethod().Name;
        var properties = this.GetType().GetProperties();
        var variables  = this.GetType().GetFields(); // public fields
    }
