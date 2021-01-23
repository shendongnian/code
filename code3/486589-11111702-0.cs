    [HttpPost]
    public virtual ActionResult AddEntity(string viewModel)
    {
        //Deserialize using Json.NET
        var entity = JsonConvert.DeserializeObject<MyEntity>(viewModel);
        var success = DoSomething(); //returns boolean
        if(success)
        {
            var result = new ResultsViewModel { MyEntity = entity, MessageId = 1};
            return RedirectToAction(MVC.MyController.ResultsPage(result));
        }
        var result = new ResultsViewModel { MyEntity = entity, MessageId = 2};
        TempData["Result"] = result;
        return RedirectToAction(MVC.MyController.ResultsPage(result));
    }
    public virtual ActionResult ResultsPage()
    {
        ResultsViewModel model = (ResultsViewModel)TempData["Result"];
        return View(model);
    }
