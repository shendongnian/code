    var result = 
        (from r in myTable.AsEnumerable()
         group r by new 
         {
             jobId = r.Field<int>("JobId"),
             stateId = r.Field<int>("StateId")
         } into g
         select new 
         {
             g.Key,
             Salaries = g.Select(x => x.Field<double>("Salary")),
             Expenses = g.Select(x => x.Field<double>("Expense"))
         })
        .ToDictionary(
            l => Tuple.Create(l.Key.jobId, l.Key.stateId),
            l => new { l.Salaries, l.Expenses }
        );
