    [Httpost]
    public ActionResult Create(User model)
    {
       if(ModelState.IsValid)
       {
         //Save and redirect
       }
       else
       {
         foreach (var modelStateVal in ViewData.ModelState.Values)
         {
           foreach (var error in modelStateVal.Errors)
           {               
              var errorMessage = error.ErrorMessage;
              var exception = error.Exception;
              // You may log the errors if you want
           }
         }
       }         
       return View(model);
     }
    }
