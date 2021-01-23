    (from list in destinctList 
    join ca in someContext.ClientAlias on list.ClientName equals ca.Name into list_client_join 
    //where list_client_join.Any ()
    from list_client in list_client_join.DefaultIfEmpty() 
    join cpa in someContext.ClientProductAlias on new { ClientID = (long)list.ClientID, Name = list.ClientProductName } equals 
       new { cpa.ClientID, cpa.Name } into j1 
    // maybe needs the following:
    where j1.Any ()
    from j2 in j1.DefaultIfEmpty() 
    orderby list_client.CreationDate descending 
    orderby j2.CreationDate descending 
    select new { ClientID = list_client.ClientID,  
    			 ClientName = list.ClientName,  
    			 ClientProductID = j2.ClientProductID,  
    			 ClientProductName = list.ClientProductName }).ToList(); 
