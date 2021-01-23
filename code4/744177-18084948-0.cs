    var myCostPages = currentSelectionForExistingData
        .GroupBy(x => new { x.CostPageContent.Program, x.CostPageContent.Group, 
                            x.CostPageContent.Sequence })
        .Select(y => new CostPage { CostPageContent = y.First().CostPageContent })
        .ToList();
