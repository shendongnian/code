    public JsonResult _columns(int attributeCode)
    {
        var services = db.Services.AsQueryable();
        var jcontainer = new MyJSONContainer();
        foreach(var service in services) 
            jcontainer.addEntry(service.description, service.GetValueFor(attributeCode));
        
        return Json(jcontainer);
    
    }
