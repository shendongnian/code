      var Query = commonFilter.Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Day= g.Key.Day,
                    TotErr = g.Count(),
                    column1 = g.Sum(o => o.Process.Contains("something") ? 1 : 0),
                    column2= g.Sum(o => o.Process.Contains(".something1") ? 1 : 0),
                    column3= g.Sum(o => o.Process.Contains(".something2") ? 1 : 0),
                    column4= g.Sum(o => o.Process.Contains("something3") ? 1 : 0),
                    column5= g.Sum(o => o.Process.Contains(".something4") ? 1 : 0),
                    column6 = g.Sum(o => o.Process.Contains(".something5") ? 1 : 0),
                    column7= g.Sum(o => o.Process.Contains(".something6") ? 1 : 0),
                    column8= g.Sum(o => o.Process.Contains(".something7") ? 1 : 0),
                    column9= g.Sum(o => o.Process.Contains(".something8") ? 1 : 0),
                    NumOrgs = g.Select(l => l.OrganizationId).Distinct().Count(),
                    NumUsers = g.Select(l => l.UserId).Distinct().Count(),
                });
        if (request.Equals("some text"))
        {
            var filter = Query.GroupBy(x => new
                {
                    x.Timestamp.Year,
                    x.Timestamp.Month,
                }) ;
        }
        //Same thing again but slightly different
        else if (request.Equals("some other text"))
        {
            var filter = Query.GroupBy(x => new
                {
                    x.Timestamp.Year,
                    x.Timestamp.Month,
                    x.Timestamp.Day
                });
        }
