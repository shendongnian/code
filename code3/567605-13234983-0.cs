    var pcPageList = db.PcPages
          .Where(m => m.Quarter == exactQuarter && m.Url == pageUrl)
          // You may need to materialize the results of the query at this point
          //   or use Convert.ToDateTime(...) instead of ToDateTime()
          .Select(m => new { Row = m, UpdatedOn = m.UpdatedOn.ToDateTime() })
          .Where(a => a.UpdatedOn.Month == 11 && a.UpdatedOn.Day == 2)
          .Select(a => a.Row)
          .OrderBy(m => m.UpdatedOn)
          .FirstOrDefault();
