	// alternate query
	(from list in destinctList  
	let ca = someContext.ClientAlias
                .OrderByDescending (cca => cca.CreationDate)
                .FirstOrDefault (cca => cca.Name == list.ClientName)
	let cca = someContext.ClientProductAlias
                .OrderByDescending (ccpa => ccpa.CreationDate)
                .FirstOrDefault(ccpa => int.Equals(ccpa.ClientID,
                               ca == null ? -1 : ca.ClientID) && 
                              string.Equals(ccpa.Name,list.ClientProductName))
	select new
	{
		ClientID = ca != null ? ca.ClientID : -1,
		ClientName = list.ClientName,
		ClientProductID = cca != null ? cca.ClientProductID : -1,
		ClientProductName = list.ClientProductName 
	}
	).ToList();  	
