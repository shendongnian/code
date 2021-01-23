    public void SaveTeam(Team team)
        {
            if (team.Id == 0)
            {
                context.Teams.Add(team);
            }
            else if (team.Id > 0)
            {
                //This Updates N-Level deep Object grapgh
                var currentTeam = context.Teams
                    .Include(c => c.TeamContact)
                    .Include(a => a.TeamContact.TeamAddress)
                    .Single(t => t.Id == team.Id);
                context.Entry(currentTeam).CurrentValues.SetValues(team);
                currentTeam.TeamContact.TeamAddress = team.TeamContact.TeamAddress;
                currentTeam.TeamContact = team.TeamContact;
            }
            context.SaveChanges();
        }
