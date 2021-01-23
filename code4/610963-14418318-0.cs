    var query = from p in PriceLogList
                group p by p.LogDateTime.ToString("MMM yyyy") into g
                select new { 
                   LogDate = g.Key,
                   AvgGoldPrice = (int)g.Average(x => x.GoldPrice), 
                   AvgSilverPrice = (int)g.Average(x => x.SilverPrice)
                };
