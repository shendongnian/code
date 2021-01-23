    // Filter
    var query = new UsersEntities().UsersTable.Select(x => x);
    if (!String.IsNullOrEmpty(nameFilter) {
        query = query.Where(x => x.Name == nameFilter);
    }
    if (!String.IsNullOrEmpty(zipFilter) {
        query = query.Where(x => x.Zip == zipFilter);
    }
 
    // Sorting
    switch (sortField)
    {
        case "Name":
            query = query.OrderBy(x => x.Name);
            break;
        case "Zip":
            query = query.OrderBy(x => x.Zip);
            break;
    }
