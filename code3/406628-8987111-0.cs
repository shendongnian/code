    public ActionResult GetCallerEquipment(string networkName)
    {
        var model = repository.GetCallerEquipment(networkName);
        return PartialView(model);
    }
