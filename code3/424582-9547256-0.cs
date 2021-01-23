    var filter = "a";
    var pageSize = 2;
    var pageIndex = 1;
    
    // get the correct products
    var query = Products.AsQueryable();
    
    query = query.Where (q => q.Name.Contains(filter));
    query = query.OrderBy (q => q.SortOrder).ThenBy(q => q.Name);
    
    // do paging
    query = query.Skip(pageSize*pageIndex).Take(pageSize);
    
    // now get products + categories as tree structure
    var query2 = query.Select(
    	q=>new 
    	{
    		q.Name, 
    		Categories=q.ProductsInCategories.Select (pic => pic.Category)
    	});
