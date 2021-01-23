    var results = context.table.GroupBy( t=> t.GroupByThisColID)
        .Select( g => new CustomClass()
            {
                GroupByThisColID = g.Key,
                ColumnSum = g.Sum( p => p.NumberIWantToSum)
            });
