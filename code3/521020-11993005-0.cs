    var users = entities.UserTable;
    
    // Setup the default order column.
    Func<SweetEntity, string> orderFunc = u => u.Field1;
    
    switch (searchfield)
    {
    	case "Field1":
    		orderFunc = u => u.Field1;
    		users = users.Where(u => u.Field1.Contains(search));
    		break;
    	case "Field2":
    		orderFunc = u => u.Field2;
    		users = users.Where(u => u.Field2.Contains(search));
    		break;
    }
    
    // If you need to get the total count, do it here:
    var totalUserCount = users.Count();
    
    // Apply sorting:
    if (order_sort == "ASC")
    {
    	users = users.OrderBy(orderFunc);
    }
    else
    {
    	users = users.OrderByDescending(orderFunc);
    }
    
    // Apply paging:
    users = users.Skip(Convert.ToInt32(limit_begin)).Take(Convert.ToInt32(limit_end));
