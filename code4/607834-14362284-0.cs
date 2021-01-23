    public ActionResult Create(MyModel model){
     if(ModelState.isValid){
           // DB Save
           return RedirectToAction("Index");
     }
     else{
           return PartialView("_myPartialForm",model);
     }
    }
