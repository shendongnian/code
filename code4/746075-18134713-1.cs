    public Somethings GetSomethingsById(int id)
    	{
    		Somethings retVal = new Somethings();
    		U22.QueryProvider provider = new U22.AXQueryProvider(null);
    		U22.QueryCollection<Somethings> somethings = new U22.QueryCollection<Somethings>(provider);
    		var somethings2 = somethings.Where(x => x.SomethingId == id);
    		retVal = somethings2.FirstOrDefault();
    		return retVal;
    	}
