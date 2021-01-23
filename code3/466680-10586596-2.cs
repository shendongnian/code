    public ActionResult GetInfo(string id,string vehicleTypId)
    {
      if(String.IsNullOrEmpty(vehicleTypeId))
      {
        var vehicle=GetVehicleType(vehicleTypId);
        return View("ShowSpecificVehicle",vehicle)    ;
      }
      
      var genericVehicle=GetVehicle(id);
      return View(genericVehicle);
    
    }
