	List<string> zipcodesNearBy = new List<string>();
	if(goodOrder.Customer != null)
	{
		if(goodOrder.Customer.Address != null)
		{
			if(goodOrder.Customer.Address.City != null)
			{
				if(goodOrder.Customer.Address.City.ZipCodes != null)
				{
					zipcodesNearBy = goodOrder.Customer.Address.City.ZipCodes;
				}
				else { /* do something else? throw? */ }
			}
			else { /* do something else? throw? */ }
		}
		else { /* do something else? throw? */ }
	}
	else { /* do something else? throw? */ }
