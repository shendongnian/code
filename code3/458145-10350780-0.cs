    public ActionResul Index()
    {
      var items=dbContext.Items;
      return View("Focus",items);
    }
