    //GET
    public ActionResult CreateNewEntity()
    {
        YourEntity newEntity= new YourEntity ();
        newEntity.WEIGHT= 0;
    
        return View(newEntity);
    }
