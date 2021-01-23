    [HttpPost]
    public ActionResult VehicleTypes(VehicleTypesViewModel model)
    {
      int typeId=model.SelectedTypeId;
      return RedirectToAction("GetVehicle",new {@id=typeId});
    }
    public ActionResult GetVehicle(int id)
    {
      var specificVehicle=dbContext.Vehicles.Where(x=>x.TypeIdid);
      return View(specificVehicle);
 
    }
