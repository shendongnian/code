    public async Task<ActionResult> Index()
    {
      var api = new Api();
      var test = await api.Get(); // Should return
    }
