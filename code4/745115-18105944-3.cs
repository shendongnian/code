    static void Main(string[] args)
    {
        var teams = new[]
        {
            new { Name = "Team 1"},
            new { Name = "Team 2"},
            new { Name = "Team 3"},
            new { Name = "Team 4"},
            new { Name = "Team 5"}
        };
        var matches = 
            // here we loop over all the items in the teams collection. 
            // "teamA" is our loop variable.
            from teamA in teams
            // here we loop over all the items in the teams collection again.
            // like a nested foreach (in) 
            // "teamB" is our loop variable.
            from teamB in teams
            
            // this is like an if(teamA.Name != teamB.Name) within our nested foreach loops
            where teamA.Name != teamB.Name
            // the select says how we want to create our collection of results.
            // Here we're creating a new anonymous object containing the two rival teams.
            select new { Team1 = teamA, Team2 = teamB };
        foreach (var match in matches)
        {
            var result = PlayMatch(match.Team1, match.Team2);
            Console.WriteLine("{0} played {1} The result was {2}", 
                match.Team1.Name, 
                match.Team2.Name, 
                result);
        }
    }
    private static string PlayMatch(object team1, object team2)
    {
        // Left as an exercise for the OP.
        return "...";
    }
