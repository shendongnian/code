    var sqlQuery = from d in data
                   group d by new { d.LocationName, d.Year, d.Month, 
                                    d.Denominator, d.Numerator } into groupItem
                   orderby groupItem.Key.Year, groupItem.Key.Month, 
                           groupItem.Key.LocationName 
                   select new
                   {
                       IndicatorName,
                       groupItem.Key.LocationName,
                       groupItem.Key.Year,
                       groupItem.Key.Month,
                       Numerator = groupItem.Sum(x => x.Numerator),
                       groupItem.Key.Denominator,
                   };
    var finalResult = sqlQuery.AsEnumerable()
         .Select(item => new {
                     item.IndicatorName,
                     item.LocationName,
                     Year = item.Year == null ? "Not Available" 
                                              : item.Year.ToString(),
                     Month = item.Month == null ? "Not Available" 
                                                : item.Month.ToString("00"),
                     item.Numerator,
                     item.Denominator
                 })
         .ToList();
