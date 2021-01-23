    [HttpPost]
    public PartialViewResult SomeMethodInController()
    {
    	var model = MethodToRetreiveModel();
    
    	return PartialView( "_MyPartialView", model );
    }
