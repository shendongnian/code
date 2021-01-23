    class ParameterModel: JobParameter
    {
        public JobParameter ToDomain()
        {
            var domainObject = JobParameter.Factory(Type);
            Mapper.Map(this, domainObject);
            return domainObject;
        }
        public bool Validate()
        {
            var dom = ToDomain();
            return TryValidate(dom);
        }
    }
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
