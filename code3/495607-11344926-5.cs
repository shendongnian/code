    var match = AcademicYear.RetrieveAll()
                   .Where(ay =>
                       Org.RetrieveDistinctYear.Select(y => y.AcademicYearCode)
                           .Contains(ay.Code))
                   .FirstOrDefault();
    if (match != null)
    {
        ddlYear.Items.Insert(0, new ListItem(match.Name, match.Code)); 
    }
