    public static Exception LogMessage(Exception ex)
    {
        Trace.WriteLine(ex.ToString());
        return ex; 
    }
