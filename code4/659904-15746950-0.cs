    [HttpPost]
    public ActionResultCreate(RawValues model)
    {
     ....
    
     if (!ModelState.IsValid)
     {
        ModelState.AddModelError("KeyActiveMg", "KeyActiveMg field is required");
        var model = new GetModel();
        return View("Results", model);
     }  
    
        rawvaluesRepository.InsertOrUpdate(rawvalues);
        rawvaluesRepository.Save();
        List<Results> results = Helpers.OperationContext.CallCalculate(rawvalues);
        return View("Results", results);
    }
