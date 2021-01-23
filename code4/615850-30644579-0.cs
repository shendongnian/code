    public IEnumerable<string> Get()
    {
        return this.Repository.GetAll();
    }
    [HttpGet]
    public void ReSeed()
    {
        // Your custom action here
    }
