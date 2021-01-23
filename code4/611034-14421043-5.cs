    var reader = new Query<Employee>(new MonthlyReportFields{ IncludeSalary = true })
        .Where(new CurrentMonthCondition())
        .Where(new DivisionCondition{ DivisionType = DivisionType.Production})
        .OrderBy(new StandardMonthlyReportSorting())
        .ExecuteReader();
