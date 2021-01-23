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
        var fields = this.GetType().GetFields(); // public fields
        // for example:
        foreach (var prop in properties)
        {
            var value = prop.GetValue(this, null);
        }
        foreach (var field in fields)
        {
            var value = field.GetValue(this);
        }
        foreach (string key in Session) 
        {
            var value = Session[s];
        }
    }
