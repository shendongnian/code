    CreateTaskGroup(args);
    //.....
    public static int CreateTaskGroup(params string[] args) {
        if (args.Length == 0) throw new Exception("nope!");
        args = args.Concat(Enumerable.Range(0, 5 - args.Length)
            .Select<int, string>(_ => null)).ToArray();
        string TaskGroupName = args[0];
        string Market = args[1] ?? "en-us";
        string Project = args[2] ?? "MyProject";
        string Team = args[3] ?? "DefaultTeam";
        string SatelliteID = args[4] ?? "abc";
        //......
    }
