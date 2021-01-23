    var userVotes = ctx.Responses.GroupBy(x => x.UserId )
                                 .ToDictionary(a => a.Key.UserId,  b => b.Count());
    var cityQuery = ctx.Responses.ToList().Where(x => userVotes[x.UserId] >= VALID_RESPONSES)
                   .GroupBy(x => new { x.User.AwardCity, x.Category.Label, x.ResponseText })
                   .Select(r => new
                           {
                               City = r.First().User.AwardCity,
                               Category = r.First().Category.Label,
                               Response = r.First().ResponseText,
                               Votes = r.Count()
                           })
                   .OrderByDescending(r => r.City, r.Category, r.Votes());
