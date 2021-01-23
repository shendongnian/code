    foreach(var team in allTeams.OfType<Team>())
    {
        if(team.TeamName.Equals(nameToMatch, StringComparison.InvariantCultureIgnoreCase))
        { 
          frmTeam = new FormTeam(Team); 
          Aplication.Run(frmTeam); // or frmTeam.Show();
          break;
        }
    }
