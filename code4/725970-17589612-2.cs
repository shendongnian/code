    [HttpPost]
    public ActionResult SaveAnsDetails(FormCollection collection)
    {
    	var model = new ModelGridAllFeatures();
    	TryUpdateModel(model, new string[]
    	{
    		"classs",
    		"ExamDate",
    		"ddd"
    	}, collection.ToValueProvider());
    }
