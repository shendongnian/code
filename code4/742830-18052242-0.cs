    [HttpPost]
    public ActionResult Save(MyModel model) {
        var oldModel = JsonConvert.DeserializeObject<MyModel>(Form["OldModel"]);
        if (oldModel.Url != model.Url) { 
            // code to save the Url field only
        }
    }
