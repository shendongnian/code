    public TeamForm(Team team)
    {
        teamName.Text = team.TeamName;   // label or something
        teamPlayerCount.text = team.PlayerCount.ToString();
        ...
    }
