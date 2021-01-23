    if (ModelState.IsValid)
            {
        //do stuff
            }
       else
       {
          ModelState.AddModelError("RegisterModel Errors", "some error occured");
       } 
    
           return View(model);
