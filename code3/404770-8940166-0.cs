        using (IDemoContext dbi = new DemoContext())
        {
        var memberset = dbi.Members.Include(i => i.SecondaryTeams);
        var members =
            (from member in memberset
            select new
            {
                Name = member.Name,
                Team = member.PrimaryTeam.Name,
                SecondaryTeams = from secondaryTeam in member.SecondaryTeams
                                    join primaryMember in memberset
                    on secondaryTeam.ID equals primaryMember.PrimaryTeamID
                    into secondaryTeamMembers
                    select new
                    {
                        Name = secondaryTeam.Name,
                        Count = secondaryTeamMembers.Count()
                    }
            }).ToList();
        }
