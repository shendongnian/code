     ProcessedCPLeaves
    .GroupBy(item => new { 
                     LeaveTypeName = item.LeaveTypeName,
                     EmpUserName = item.EmpUserName,
                     ProcessingDate = item.ProcessingDate
    }).Select (grouping => new {
                     EmpUserName =grouping.Key.EmpUserName,
                     LeaveTypeName = grouping.Key.LeaveTypeName,
                     TotalCount= grouping.Count()
    });
