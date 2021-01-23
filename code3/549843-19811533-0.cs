    [HttpGet]
    public IEnumerable<object> TestGet1()
    {
        return new string[] { "value1", "value2" };
    }
    [HttpGet]
    public IEnumerable<object> TestGet2()
    {
        return new string[] { "value3", "value4" };
    }
