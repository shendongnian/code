    public ActionResult GetVehicalInfo(string id, string vehicleType)
    {
        var vehicle = GetVehicleType(id, vehicleTypId);
        return PartialView("vehicle);      
    }
