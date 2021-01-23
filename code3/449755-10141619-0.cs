    var monthlist1 = data.
        Select(x => new { wkdate = x.WKENDDATE }).
        OrderBy(x=> CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month)).
        ThenBy(x=> x.Year).
        Select(m => new { 
            monthname = m.wkdate.ToString("MMM yyyy", 
                                          CultureInfo.CreateSpecificCulture("en-US")) 
            }).
        Distinct().
        ToList();
