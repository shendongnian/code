    var allYears = AcademicYear.RetrieveAll().ToDictionary(y => y.Code, y.Name);
    var matchingCode = Org.RetrieveDistinctYear()
        .Select(y = y.AcademicYearCode)
        .FirstOrDefault(code => allYears.HasKey(code));
    if (!string.IsEmptyOrWhitespace(matchingCode))
    {
        ddlYear.Items.Insert(0, new ListItem(
                                     allYears[matchingCode], 
                                     matchingCode)); 
    }
