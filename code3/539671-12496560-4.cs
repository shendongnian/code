    var myDate = DateTime.Now.Date();
    var res = histories.AsQueryable()
    .Where(m => 
    EntityFunctions.CreateDateTime(m.FromDate.Year, m.FromDate.Month, m.FromDate.Day, 0, 0, 0) >= DateTime.Now && 
    EntityFunctions.CreateDateTime(m.ToDate.Year, m.ToDate.Month, m.ToDate.Day, 0, 0, 0) <= DateTime.Now)
