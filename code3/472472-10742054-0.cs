    // In the controller
    public ActionResult DoStuff()
    {
        // get your model
        ViewBag.OriginalModel = YourModel;
        return View(YourModel);
    }
    // In the View
    <input type="hidden" name="originalModel" value="@Html.Raw(Json.Encode(ViewBag.OriginalModel));" />
    // In the controller's post...
    [HttpPost]
    public ActionResult DoStuff(YourModel yourModel, string originalModel)
    {
        // yourModel will be the posted data.
        JavaScriptSerializer JSS = new JavaScriptSerializer();
        YourModel origModel = JSS.Deserialize<YourModel>(originalModel);
    }
