    [HttpPost]
    public JsonResult Save(MyViewModel viewModel)
    {
        // do something with the data...
        string expectedName = viewModel.FirstName;
        return Json(expectedName);
    }
