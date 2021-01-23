    [HttpPost]
    public ActionResult Create(MyView viewModel)
    {
       ModelState.Remove("MyReadOnlyProperty");
    }
