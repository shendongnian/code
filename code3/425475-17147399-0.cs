    // GET api/MyObjects/5
    // GET api/MyObjects/function
    public object GetMyObjects(string id)
    {
    	id = (id ?? "").Trim();
    
    	if (string.Equals(id, "count", StringComparison.OrdinalIgnoreCase))
    	{
    		return db.MyObjects.LongCount();
    	}
    
    	var myObject = db.MyObjects.Find(long.Parse(id));
    	if (myObject == null)
    	{
    		throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
    	}
    
    	return myObject;
    }
