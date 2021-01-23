    allTeams.OfType<Team>().Any(team =>
    {
        if(team.TeamName.Equals(nameToMatch, StringComparison.InvariantCultureIgnoreCase))
        { 
          frmTeam = new FormTeam(Team); 
          frmTeam.Show();
        }
        else return false;
    });
