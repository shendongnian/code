    var monthlist1 = data.Select(m => new DateTime(m.WKENDDATE.Year,
                                                     m.WKENDDATE.Month,
                                                     1);
    var monthlist2a = 
        data.Select(x => 
            new { wkdate = ExportHelper.getSplitEndDate(x.WKENDDATE).AddDay(1)})
        .Where(l => 
            ExportHelper.isSplitWeek(l.wkdate.AddDays(-6), l.wkdate) == true);
    var monthlist2b = monthlist2a.Select(m => new DateTime(m.WKENDDATE.Year,
                                                     m.WKENDDATE.Month,
                                                     1);
    var monthlist = monthlist1.Union(monthlist2b).Distinct()
                     .OrderBy(m => (m.Year * 100) + m.Month)
                     .Select(m => 
            m.ToString("MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));
