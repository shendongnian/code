    var sqlMinDate = (DateTime) SqlDateTime.MinValue; 
    (from x in ExpenseItemsViewableDirect
    let month = EntityFunctions.AddMonths(sqlMinDate, EntityFunctions.DiffMonths(sqlMinDate, x.Er_Approved_Date))
    group d by month 
    into g
    select new
    {
    Period = g.Key,
       Total = g.Sum(x => x.Item_Amount),
       AveragePerTrans = Math.Round(g.Average(x => x.Item_Amount),2)
    }).Dump();
