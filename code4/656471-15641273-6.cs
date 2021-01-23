    // /api/lookups/get
    public string Get()
    {
        return "Default Get";
    }
    // /api/lookups/custom
    [ActionName("custom")]
    [HttpGet]
    public string CustomLookup()
    {
        return "Hello, World";
    }
