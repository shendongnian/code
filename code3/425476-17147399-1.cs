    // GET api/MyObjects/5
    // GET api/MyObjects/function
    public object GetMyObjects(string id)
    {
        id = (id ?? "").Trim();
    
        // Check to see if "id" is equal to a "command" we support
        // and return alternate data.
    
        if (string.Equals(id, "count", StringComparison.OrdinalIgnoreCase))
        {
            return db.MyObjects.LongCount();
        }
    
        // We now return you back to your regularly scheduled
        // web service handler (more or less)
        var myObject = db.MyObjects.Find(long.Parse(id));
        if (myObject == null)
        {
    	    throw new HttpResponseException
            (
                Request.CreateResponse(HttpStatusCode.NotFound)
            );
        }
    
        return myObject;
    }
