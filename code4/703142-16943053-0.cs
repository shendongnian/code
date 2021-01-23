    // Create a query
    ICriteria query = Session.CreateCriteria<WorkShopItem>("wsi");
    // Restrict to items due within the next 14 days
    query.Add(Restrictions.Le("DateDue", DateTime.Now.AddDays(14));
   
    // Return all TaskNames from Todo's
    DetachedCriteria allTodos = DetachedCriteria.For(typeof(Todo)).SetProjection(Projections.Property("TaskName"));
    // Filter Work Shop Items for any that do not have a To-do item 
    query.Add(SubQueries.PropertyNotIn("Name", allTodos);
    // Return results
    var matchingItems = query.Future<WorkShopItem>().ToList()
