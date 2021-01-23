    var query = from o in context.table
                where o.GroupByThisColID == GroupByThisColID
                group o by o.Date into grouping
                select new CustomClass()
                {
                    ID = grouping.First().ID,
                    Date = grouping.Key,
                    SummedNumbers = grouping.Sum(g => g.NumberIWantToSum),
                    GroupByThisColID  = grouping.First().GroupByThisColID
                };
