    [OutputCache(Duration = 300, VaryByParam="*")] 
    public ActionResult TextPage(string pageid) 
    { 
      var model = textPageController.GetPage(pageid); 
      return View(model);
    }
