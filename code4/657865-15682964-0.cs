              [HttpPost]
            public ActionResult PostJobAction(FormCollection PostJobForm, HttpPostedFileBase uploadfile, JobsDetailModel objLocationModel)
            {
               if(ModelState.IsValid)
                   {
                     return View(objLocationModel);
                 }
                else
                {
                  // Dropdown selected values  needs to be repopulated here , if there   error in the model.
                   return View(objLocationModel);
                }
            }
