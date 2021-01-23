    public JsonResult ByContainer(int id)
    {
        var elementIds = _systemSettings.Z3FromZBIds; // CritialWorkPermitIds; 
        var kpiElements = CacheService.AllVisibleElements
                                        .Where(x => elementIds.Contains(x.Id)).ToList();
        var container = _kpiContainerService.Find(id);
        var result = _kpiTrendService.MonthByContainer(kpiElements, container);
            
        return Json(result, JsonRequestBehavior.AllowGet);
    } 
