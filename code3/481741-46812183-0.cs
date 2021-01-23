    [HttpPost]
    [Route("MyRoute")]
    public IHttpActionResult DoWork(MyClass args)
    {
       ...
    }
    
    [JsonObject(MemberSerialization.OptOut)]
    public Class MyClass
    {
        ...
    }
