    [HttpGet]
    public ActionResult ExampleKo()
    {
        return View();
    }
    [HttpPost]
    public ActionResult ExampleKo(ExampleKoViewModel viewModel)
    {
        // Do something with the value passed back
        string debugMessage = "Hello there " + viewModel.SimpleName;
        return View();
    }
    [OutputCache(Duration=0,VaryByParam="none")]
    public JsonResult KnockoutViewModelTest()
    {
        // Build up our view model
        var viewModel = new ExampleKoViewModel();
        viewModel.SimpleName = "Fred Bloggs";
        // Send back as a Json result
        var result = new JsonResult();
        result.Data = viewModel;
        return Json(result, JsonRequestBehavior.AllowGet);
    }
