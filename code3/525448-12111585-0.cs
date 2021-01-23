    public ActionResult Contact(string id)
    {
       var client = _repository.GetClient(id);
       var model = new RequestModel(){ /* set your properties from client */ };
    
       return View(model);
    }
