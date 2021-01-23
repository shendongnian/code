    [HttpPost]
    [FormValueRequired("btndegreeconfirmYes")]        
         public ActionResult CheckData()
         {
           Response.Write(submit);                    
           return RedirectToRoute("detailform");
         }
