    public ActionResult MyResults()
    {
      var model=TempData["Jobs"] as List<int>;
      return View(model);
    }
