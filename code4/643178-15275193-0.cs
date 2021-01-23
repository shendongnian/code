    var allItemsList = new List<allItems>() { ... fill in items ... };
    var asItems = 
        from item in allItemsList
        group item by new { item.WeekNumber, item.monthNumber } into byWeekMonth
        from grp in byWeekMonth
        select new items()
        {
             weekNumber = grp.Key.weekNumber,
             monthNumber = grp.Key.monthNumber,
             days = grp.Select(si => 
                  new subItems()
                  {
                      punchedInLate = si.punchedInLate,
                      punchedOutLate = si.punchedOutLate,
                      // etc, other fields
                  }.ToList()
              }
        };
