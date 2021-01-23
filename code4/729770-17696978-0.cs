    static class JsonResultBuilder
    {	
    	public static JsonResult Build(Database db, int attributeCode)
    	{
    		var propertyRetriever = JsonServicePropertyRetrievers.Get(attributeCode);
    	
    		IQueryable<Service> services = db.Services.AsQueryable();
    		MyJSONContainer jcontainer = new MyJSONContainer();
    		
    		foreach(Service s in services)
    			jcontainer.addEntry(s.Description, propertyRetriever(s));
    			
    		return Json(jcontainer);
    	}
    }
