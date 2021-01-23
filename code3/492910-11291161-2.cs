    DateTime endDate = DateTime.Now;
    DateTime startDate = endDate.AddMonths(-Months);
    var result = Session.QueryOver<Application>()
        .WhereRestrictionOn(c => c.SubmissionDate).IsBetween(startDate).And(endDate)
        .SelectList(list => list
            .Select(Projections.SqlGroupProjection(
            "YEAR(SubmissionDate) As [Year]",
            "YEAR(SubmissionDate)",
            new[] { "YEAR" },
            new IType[] { NHibernateUtil.Int32 }))
        .Select(Projections.SqlGroupProjection(
            "MONTH(SubmissionDate) As [Month]",
            "MONTH(SubmissionDate)",
            new[] { "MONTH" },
            new IType[] { NHibernateUtil.Int32 }))
        .SelectCount(x => x.Id))
        .List<object[]>()
        .Select(n => new
        {
            Year = (int)n[0],
            Month = (int)n[1],
            Count = (int)n[2]
        }).ToList();
    var finalResult = result
        .Union(
            Enumerable.Range(0, Months - 1).Select(n => new
            {
                Year = startDate.AddMonths(n).Year,
                Month = startDate.AddMonths(n).Month,
                Count = 0
            })
            .Where(n => !result.Any(r => r.Year == n.Year && r.Month == n.Month)))
        .OrderBy(n => n.Year).ThenBy(n => n.Month);
