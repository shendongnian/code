    var query = from p in PriceLogList
                group p by p.LogDateTime.ToString("MMM yyyy") into g
                select new PriceLog { 
                   LogDateTime = DateTime.Parse(g.Key),
                   GoldPrice = (int)g.Average(x => x.GoldPrice), 
                   SilverPrice = (int)g.Average(x => x.SilverPrice)
                };
