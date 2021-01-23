     public ActionResult ApplicationDetail(int id)
     {
          var model = _serviceLayer.GetSomeModel(id); 
          var viewModel = model.CreateInstance(model);      
          return View(viewModel);
     }
