    [HttpPost]
    public ActionResult GetFacilityDetails(int regionId, string facilityId)
    {
        try
        {
            var facility = buildingsVM.GetFacilityDetails(regionId, facilityId);
            facility.Buildings = buildingsVM.GetFacilityBuildings(regionId, facilityId) as List<BuildingModel>;
            return PartialView("_Buildings", facility.Buildings);
        }
        catch (Exception ex)
        {
            return Json(new { ok = false, message = ex.Message });
        }
    }
