    var res = ctx.Database.SqlQuery<MyResultType1>("dbo.MyStoredProcedure");
    
    foreach (var r in res)
    {
        System.Console.Out.WriteLine(
            "col1:{0}; col2:{1}; col3={2}", 
            r.Col1,
            r.Col2,
            r.Col3);
    }
