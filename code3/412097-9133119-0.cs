    list1.GroupBy(item => new { Counter = item.Counter, SrvID = item.SrvID })
         .Select(group => new { 
            ID = group.First().ID, 
            Counter = group.Key.Counter,
            SrvID = group.Key.SrvID,
            FirstName = group.First().FirstName})
         .OrderBy(item => item.ID);
