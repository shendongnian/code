    public static int CreateTaskGroup(string[] arguments)
    {
        switch (arguments.Length)
        {
        case 5:
            string SatelliteID   = arguments[4] ?? "abc";
            goto case 4;
        case 4:
            string Team          = arguments[3] ?? "DefaultTeam";
            goto case 3;
        case 3:
            string Project       = arguments[2] ?? "MyProject";
            goto case 2;
        case 2:
            string Market        = arguments[1] ?? "en-us";
            goto case 1;
        case 1:
            string TaskGroupName = arguments[0];
            break;
        case 0:
            // error handling here;
        }
    
        // function body as it was
