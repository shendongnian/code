    [HttpPost]
        public ActionResult Save(ValorationModel model)
        {
           string buttonValue = Request["submitButton"];
           if(buttonValue == "db1"){
            var result = ValorationService.Save(ValorationModel);
           }else
           {
              ....
           }         
    
            return PartialView("_ValorationDetail", ValorationModel);
        }
