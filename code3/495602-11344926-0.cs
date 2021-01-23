    var allYears = AcademicYear.RetrieveAll().ToDictionary(y => y.Code, y.Name);
    ListItem match = null;
    foreach(var year in Org.RetrieveDistinctYear())
    {
        if (allYears.HasKey(year.Code)
        {
            match = new ListItem(allYears[year.Code], year.Code);
            break;
        }
    }
    if (match != null)
    {
        ddlYear.Items.Insert(0, match); 
    }
