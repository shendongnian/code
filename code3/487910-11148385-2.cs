    public static int CreateTaskGroup(string[] arguments)
    {
        // optional error handling here
        string TaskGroupName = arguments[0];
        string Market        = arguments.ElementAtOrDefault(1) ?? "en-us";
        string Project       = arguments.ElementAtOrDefault(2) ?? "MyProject";
        string Team          = arguments.ElementAtOrDefault(3) ?? "DefaultTeam";
        string SatelliteID   = arguments.ElementAtOrDefault(4) ?? "abc";
    
        // function body as it was
