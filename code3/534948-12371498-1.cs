    [HttpPost]
    public ActionResult MyActionMethod()
    {
      foreach(var key in Request.Form.Keys)
      {
        var item = Request.Form[key];
        // Do stuff with each item
      }
    }
