    public ActionResult SomeAction(RegisterModel model)
    {
      if(ModelState.IsValid)
      {
        // perform the functionality when Mmodel is Valid
         
         return View(model);
      }
    
      // bind data to Question list if model is fail 
      model.Questions  = new List<String>(); 
      return View(model);
    }
