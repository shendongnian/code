       public ActionResult ViewStages()
       {
            //this initialize your model
            var viewModel=new List<Stages>()       
                              {
                                  new Stages()
                                      {
                                          Id = 1,
                                          Code = "any code",
                                          //etc
                                      }
                              }; 
            return View(viewModel);   //you have to pass the model to the view
         }
