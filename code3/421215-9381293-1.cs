    public ActionResult Building()
    {
        var typeCode = // get from original source?
        var model = new BuildingViewModel
        {
            BuildingTypCode = MyService.GetDescription(typeCode)
        };
        return View("Building", model);
    }
