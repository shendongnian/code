    var query = ctx.data.ToList().OrderBy(d => d.Time).
                GroupBy(d => d.Members.StepId).
                SelectMany(g => g.Select((d, place) => new { Time = d.Time, Members = d.Members, PlaceInStep = place + 1 })).
                GroupBy(d => d.Members.TeamId).
                Select(g => new 
                {
                   TeamId = g.Key, 
                   Name = g.Select(d => d.Members.Teams.TeamName).First(),  
                   Members = g.Select(d => new {Time = d.Time, PlaceInStep = d.PlaceInStep, MemberName = d.Members.MemberName}),                    
                   TotalTime = g.Aggregate(new TimeSpan(), (sum, nextData) => sum.Add(nextData.Time))
                });
