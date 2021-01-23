    public async Task<ActionResult> Get()
    {
      // Asynchronously wait for the dictionary to load if it hasn't already.
      var dict = await SharedData.MyDictionary;
      ...
      return View();
    }
