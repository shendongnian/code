    public static IEnumerable<DateTime> GetQuarterDates()
    {
        for (DateTime quarterDate = DateTime.Now.AddYears(-4); quarterDate <= DateTime.Now; quarterDate = quarterDate.AddMonths(3))
        {
            yield return quarterDate; 
        }
    }
    public static void RunSnippet()
    {
        var RMAs = new[] {
            new { Problem = "P", CreatedDate = new DateTime(2012, 6, 2) },
            new { Problem = "P", CreatedDate = new DateTime(2011, 12, 7) },
            new { Problem = "P", CreatedDate = new DateTime(2011, 12, 8) },
            new { Problem = "P", CreatedDate = new DateTime(2011, 8, 1) },
            new { Problem = "P", CreatedDate = new DateTime(2011, 4, 1) },
            new { Problem = "Q", CreatedDate = new DateTime(2011, 11, 11) },
            new { Problem = "Q", CreatedDate = new DateTime(2011, 6, 6) },
            new { Problem = "Q", CreatedDate = new DateTime(2011, 3, 3) }
        };
        var quarters = GetQuarterDates().Select(quarterDate => new { Year = quarterDate.Year, Quarter = Math.Ceiling(quarterDate.Month / 3.0) });
        
        var rmaProblemQuarters = from rma in RMAs
                where rma.CreatedDate > DateTime.Now.AddYears(-4)
                group rma by rma.Problem into rmaProblems
                select new {
                                Problem = rmaProblems.Key,
                                Quarters = (from quarter in quarters
                                            join rmaProblem in rmaProblems on quarter equals new { Year = rmaProblem.CreatedDate.Year, Quarter = Math.Ceiling(rmaProblem.CreatedDate.Month / 3.0) } into joinedQuarters
                                            from joinedQuarter in joinedQuarters.DefaultIfEmpty()
                                            select new {
                                                            Year = quarter.Year,
                                                            Quarter = quarter.Quarter,
                                                            Count = joinedQuarters.Count()
                                                       })
                           };
                
        string json = System.Web.Helpers.Json.Encode(rmaProblemQuarters);
        Console.WriteLine(json);
    }
