    var query0 = from c in dc.Prices
                 where Convert.ToDateTime(c.data).CompareTo(left) >= 0
                       && Convert.ToDateTime(c.data).CompareTo(right) <= 0
                       && c.idsticker.Equals(x)
                  group c by new { ((DateTime)c.data).Year, ((DateTime)c.data).Month }
                        into groupMonthAvg
                  select new
                  {
                      years = groupMonthAvg.Key.Year,
                      months = groupMonthAvg.Key.Month,
                      prices = groupMonthAvg.Average(x=>x.value)
                  };
