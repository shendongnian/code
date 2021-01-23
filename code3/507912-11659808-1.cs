    [HttpPost]
    [GridAction]
    public ActionResult Delete(Scenario scenario)
    {
        // Delete item and perform other operations as required
        var data = ... // Get an updated data set, with the deleted item removed
        var model = new GridModel<ScenarioVm>(data);
        return View(model);
    }
