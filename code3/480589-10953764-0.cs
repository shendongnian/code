            var RMAs = new[] {new { Problem = "P", CreatedDate = new DateTime(2012, 12, 1) },
            new { Problem = "P", CreatedDate = new DateTime(2012, 12, 7) },
            new { Problem = "P", CreatedDate = new DateTime(2012, 8, 1) },
            new { Problem = "P", CreatedDate = new DateTime(2012, 4, 1) },
            new { Problem = "Q", CreatedDate = new DateTime(2012, 11, 11) },
            new { Problem = "Q", CreatedDate = new DateTime(2012, 6, 6) },
            new { Problem = "Q", CreatedDate = new DateTime(2012, 3, 3) }};
            var j = RMAs
                     .Where(r => r.CreatedDate.Year > DateTime.Now.Year - 4) //Only grab the last 4 years worth of RMAs
                     .GroupBy(r => new { Problem = r.Problem })
                     .Select(r => new
                                 {
                                     Problem = r.Key.Problem,
                                     Quarters = r.GroupBy(q => new
                                     {
                                         Year = q.CreatedDate.Year
                                         ,
                                         Quarter = ((q.CreatedDate.Month) / 3)
                                     }).Select(q => new { Year = q.Key.Year, Quarters = q.Key.Quarter, Count = q.Count() })
                                 });
            string enc = System.Web.Helpers.Json.Encode(j);
