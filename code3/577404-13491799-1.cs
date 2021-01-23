    var query = ctx.Data.Join(ctx.Members, d => d.MemberId, m => m.MemberId, (d,m)=>new {data=d, member = m})
                    .Join(ctx.Teams, dm=>dm.member.TeamId, t=>t.TeamId, (dm, t)=>new{data=dm.data, member=dm.member, team = t})
                    .GroupBy(dmt=>new {dmt.team.TeamId, dmt.team.TeamName})
                    .Select(g=>new 
                               {
                                   TeamId = g.Key.TeamId, 
                                   TeamName = g.Key.TeamName, 
                                   TotalTime = g.Aggregate(0, (sum, gr)=>sum.Add(gr.data.Time))
                               });
