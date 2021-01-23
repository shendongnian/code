    var query = originalList.AsQueryable();
    
    if(/*Filtering on First Name*/)
    {
      query = query.where(x => x.FirstName == FirstNameSearchString);
    }
    
    if(/*Filtering on Last Name */)
    {
      query = query.where(x => x.LastName == LastNameSearchString);
    }
    
    if(/*Filtering on Number*/)
    {
      query = query.where(x => x.Number== NumberSearchString);
    }
    
    //..And so on
    
    //Do stuff with query
