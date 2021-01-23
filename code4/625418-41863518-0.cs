    [ResponseCache(Duration = 3600)]
    [HttpGet]
    public IEnumerable<Product> Get()
    {
      return _service.GetAll();
    }
