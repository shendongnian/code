    //GET
    public ActionResult CreateNewEntity()
    {
        MyEntity newMyEntity = new MyEntity();
        newMyEntity.WEIGHT= 0;
    
        return View(newMyEntity);
    }
