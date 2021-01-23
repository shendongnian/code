        using (IDemoContext dbi = new DemoContext())
        {
            var memberSet = dbi.Members;
            var members =
                (from member in memberSet
                select new
                {
                    Name = member.Name,
                    Team = member.PrimaryTeam.Name,
                    SecondaryTeams = from secondaryTeam in member.SecondaryTeams
                        join primaryMember in memberSet
                        on secondaryTeam.ID equals primaryMember.PrimaryTeamID
                        into secondaryTeamMembers
                        select new
                        {
                            Name = secondaryTeam.Name,
                            Count = secondaryTeamMembers.Count()
                        }
                }).ToList();
        }
