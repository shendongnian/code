    IEnumerable<MyType1> result = table1.Join(table2,
            t1 => new { t1.Field1, t1.Field2 },
            t2 => new { t2.Field1, t2.Field2 },
            (t1, t2) => new { table1 = t1, table2 = t2 }).
        Where(joinedResults => joinedResults.table2 == //condition).
        Select(filteredResults => filteredResults.table1);
