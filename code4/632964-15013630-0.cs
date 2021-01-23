    public List<string> CodesWithTransactionsBetweenDates(DateTime startInclusive, DateTime endExclusive, List<string> associatedCodes, int marketId)
    {
    	using (var context = new MarketPlaceEntities())
    	{
    		var list = (from transactions in context.Transactions                            
    				where
    					transactions.MarketId == marketId &&
    					transactions.Date >= startInclusive &&
    					transactions.Date < endExclusive                            
    				select transactions.User.Code).Distinct().ToList<string>();
    
    		return list.Where(c => associatedCodes.Contains(c)).ToList();
    	}            
    }
