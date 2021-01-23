    [HttpPost]
    public ActionResult Update(Record rec){ //Alternatively you can also use FormCollection object as well 
       if(TryValidateModel(rec)){
            //update code
       }
       return View("Index1");
    }
