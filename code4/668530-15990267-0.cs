    allTeams.OfType<Team>().Any(team =>
    {
        if(team.TeamName.Equals(nameToMatch, StringComparison.InvariantCultureIgnoreCase))
        {
            teamForm.TeamName = team.TeamName;
            ...
            teamForm.Show();
            return true;
        }
        else return false;
    });
