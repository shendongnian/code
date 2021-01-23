    [HttpPost]
            public ActionResult Save(ValorationModel model, string submitButton)
            {
               if(submitButton == "db1"){
                var result = ValorationService.Save(ValorationModel);
               }else
               {
                  ....
               }         
        
                return PartialView("_ValorationDetail", ValorationModel);
            }
