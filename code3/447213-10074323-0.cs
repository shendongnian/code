    var results = from a in ListA
                  join b in ListB on ai.ID equals bi.ID
                  select new
                  {
                      itemA = a,
                      itemB = b
                  };
    
    foreach(var result in results)
    {
        // This was not listed as a requirement, but it may be a valid check
        if (itemA.FirstName == itemB.FirstName)
        {
            itemB.DepartmentID = itemA.DepartmentID;
        }
    }
    
    DataContext.SubmitChanges();
