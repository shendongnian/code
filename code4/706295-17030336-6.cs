    [HttpPost]
    public JsonResult AddUpdateConfigs(QueueMonitor parameterName)  //Note parameter being same as that passed in AJAX Call.
    {
       //Logic 
    
       return Json(result, JsonRequestBehaviour.AllowGet);
    }
