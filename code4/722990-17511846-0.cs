    List<ProjectResourceCostDto> testList = new List<ProjectResourceCostDto>();
    testList.Add(new ProjectResourceCostDto{Id = 1, ProjectResourceId = 1, StartDate = new DateTime(2001,2,1), EndDate = new DateTime(2002, 1,1), Cost = 1111, Deleted = false});
    testList.Add(new ProjectResourceCostDto{Id = 2, ProjectResourceId = 2, StartDate = new DateTime(2003,1,1), EndDate = new DateTime(2004, 1,1), Cost = 0, Deleted = false});
    testList.Add(new ProjectResourceCostDto { Id = 3, ProjectResourceId = 3, StartDate = new DateTime(2005, 1, 1), EndDate = new DateTime(2006, 1, 1), Cost = 999, Deleted = false });
    
    DateTime firstDate = new DateTime(2001, 1, 1);
    DateTime lastDate = new DateTime(2006, 2, 1);
    List<DateTime> gapsList = new List<DateTime>();
    gapsList.Add(firstDate);
    testList = testList.OrderBy(n => n.StartDate).ToList();
    foreach(ProjectResourceCostDto item in testList)
    {
        if (item.Cost == 0)
        {
            gapsList.Add(item.StartDate);
            gapsList.Add((DateTime)item.EndDate);
        }
    }
    gapsList.Add(lastDate);
