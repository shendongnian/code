    var query0 = from c in dc.Prices
             where Convert.ToDateTime(c.data).CompareTo(left) >= 0
                   && Convert.ToDateTime(c.data).CompareTo(right) <= 0
                   && c.idsticker.Equals(x)
              group c by new { ((DateTime)c.data).Year, ((DateTime)c.data).Month }
                    into groupMonthAvg
              select new {
                  groupMonthAvg.Key.Year, 
                  groupMonthAvg.Key.Month, 
                  YearAverage = groupMonthAvg.Average(x=>x.Year),
                  MonthAverage = groupMonthAvg.Average(x=>x.Month)
                  };
