    public JsonResult Val()
    {
    
        SDS svr = new SDS();
        svr.A = ...
        svr.B = ...
        svr.C = ...
        
        var list = new {List = svr};
        return this.Json(list);
    }
