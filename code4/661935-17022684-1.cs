    var query =
                from A in context.A
                join B in context.B on A.ID equals B.ID
                join C in context.C on A.ID2 equals C.ID2
                where A.endtime> endtime && A.Chk.StartsWith("320")
                select new
                       {
                         A = A,
                         B = B,
                         C = C
                       };
    foreach(item i in query)
        {
            A.Calculated = A.Foo * B.Bar;
        }
    return query
