    [HttpGet]
    public ActionResult Search(string city, string q)
    {
      var model = new SearchModel {
           City = "london",
           Q = "some search term"
      };
      return View(model);
    }
    [HttpPost]
    public ActionResult Search(SearchModel model)
    {
      //.....
      return View(model);
    }
