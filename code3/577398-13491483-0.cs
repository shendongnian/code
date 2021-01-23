    var query = from data in ctx.Data
                group data by data.Members.TeamId into g
                select new 
                     {
                        TeamId = g.Key, 
                        TeamName = g.Select(d=>d.Members.Teams.TeamName).First(),
                        TotalTime = g.Aggregate(new TimeSpan(), (sum, nextData) => sum.Add(nextData.Time))}
                     };
