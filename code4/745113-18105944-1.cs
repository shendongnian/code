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
            from teamA in teams
            from teamB in teams
            where teamA.Name != teamB.Name
            select new {Team1 = teamA, Team2 = teamB};
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
