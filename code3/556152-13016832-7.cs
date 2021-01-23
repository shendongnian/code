    class Controller(){
        [HttpPost]                                
        public ActionResult SaveParameter(JobParameter model){                                
                              
             if(TryValidateModel(model)){                                
                                              
                  //persist stuff to db.
                                
              //when succesfully saved return to main display page                                 
                  return RedirectToAction("MainDisplay");                                
             }                                
             return View(main.Prop1);
        }                                
    }                                
