    String html; //your html string
    String pattern = @"action=ViewItemDetails&ItemType[I|i]D=(\d*)"">(.*)</a>";
    MatchCollection matches = Regex.Matches(html, pattern);
    var list = new List<TeamClass>();
    foreach (Match match in matches)
    {
        TeamClass team = new TeamClass();
        team.TeamName = match.Groups[2].Value;
        team.TeamId = Int32.Parse(match.Groups[1].Value);
        list.Add(team);
    }
