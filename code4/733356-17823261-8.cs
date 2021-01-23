    	var building = new BuildingModel();
    	if (ModelState.IsValid)
    	{
    		try
    		{
    			building = _presentationService.UpdateBuilding(modelIn);
    		}
    		catch (Exception e)
    		{
    			ModelState.AddModelError(string.Empty, e.Message);
    		}
    	}
    	else
    	{
    		var errMsg = ModelState.Values
    			.Where(x => x.Errors.Count >= 1)
    			.Aggregate("Model State Errors: ", (current, err) => current + err.Errors.Select(x => x.ErrorMessage));
    		ModelState.AddModelError(string.Empty, errMsg);
    	}
    	var buildings = (new List<BuildingModel> {building}).ToDataSourceResult(request, ModelState);
    	return Json(buildings, JsonRequestBehavior.AllowGet);
    }
