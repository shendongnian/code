    [HttpGet]
    public ActionResult EditProp1()
    {
        var main = db.retrieveMainModel();
        db.Prop1.SubmitUrl = Action("SaveProp1","Controller");
        return View(main.Prop1);
    }
    [HttpPost]                                
    public ActionResult SaveProp1(SomeSubModel model){                                
         var validationModel = new Prop1ValidationModel{
         ///copy properties                                   
             };
         if(TryValidateModel(validationModel)){                                
                                              
              var main = db.retrieveMainModel();                                
              main.Prop1 = model;                                
              db.Save();                                
                                
              //when succesfully saved return to main display page                                 
              return RedirectToAction("MainDisplay");                                
         }                                
         return View(main.Prop1);
    } 
