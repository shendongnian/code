    OrgCollection myYears = Org.RetrieveDistinctYear();
    if (myYears.Count > 0)
    {
        AcademicYearCollection allYears = AcademicYear.RetrieveAll();
        for (int i = 0; i < myYears.Count; i++)
        {
             if (allYears[j].Any(allY => allY ==  myYears[i].AcademicYearCode ))
                {
                    ddlYear.Items.Insert(0, new ListItem(allYears[j].Name, allYears[j].Code));
                    break;
                }
            
        }
    }
