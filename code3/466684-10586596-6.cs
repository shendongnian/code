    [HttpPost]
    public ActionResult VehicleTypes(VehicleTypesViewModel model)
    {
      // you have the selected Id in model.SelectedTypeId property
      var specificVehicle=dbContext.Vehicles.Where(x=>x.TypeId=model.SelectedTypeId);
      return View("SpecificDetails",specificVehicle);
      
    }
