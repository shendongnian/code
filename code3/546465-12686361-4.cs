    public ActionResult SomeAction(string countryId)
    {
         //perform your action here
         var states = _stateProvinceService.GetStateProvincesByCountryId(country.Id).ToList();
         var result = (from s in states
                       select new { id = s.Id, name = s.GetLocalized(x => x.Name) }
                      ).ToList();
    
       return Json(result, JsonRequestBehavior.AllowGet);
    } 
