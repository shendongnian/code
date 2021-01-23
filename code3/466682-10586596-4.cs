    public ActionResult VehicleTypes()
    {
      VehicleTypesViewModel objVM=new VehicleTypesViewModel();
      objVM.Types=dbContext.VehicleTypes.ToList();      
      return View(objVM);
    }
