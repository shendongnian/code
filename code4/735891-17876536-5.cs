    public ActionResult GetDistrictsByStateId(int stateId)
    {
         IEnumerable<District> districts = districtRepository.GetDistrictsByStateId(stateId);
    
         var displayedDistricts = districts.Select(x => new
         {
              Id = x.Id.ToString(),
              Name = x.Name
         });
    
         return Json(displayedDistricts, JsonRequestBehavior.AllowGet);
    }
