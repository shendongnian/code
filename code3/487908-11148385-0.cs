    public static int CreateTaskGroup(string[] arguments)
    {
        if (arguments.Length == 0)
        {
            // error handling here
        }
    
        string TaskGroupName = arguments[0]; // no default value, this one required
        string Market        = arguments[1] ?? "en-us";
        string Project       = arguments[2] ?? "MyProject";
        string Team          = arguments[3] ?? "DefaultTeam";
        string SatelliteID   = arguments[4] ?? "abc";
    
        // function body as it was
