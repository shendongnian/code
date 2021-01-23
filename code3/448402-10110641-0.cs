    [HttpPost]
    public ActionResult Edit(string id, Business business)
    {
    	try
    	{
    		var model = _businessRepository.Get(id);
    
    		if (model != null)
    		{
    			Mapper.Map(business, model);
    
    			if (ModelState.IsValid)
    			{
    				_businessRepository.Save(model);
    			}
    			else
    			{
    				return View(business);
    			}
    		}
    
    		return RedirectToAction("Index");
    	}
    	catch
    	{
    		return View();
    	}
    }
