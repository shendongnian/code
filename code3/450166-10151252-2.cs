    [AcceptVerbs(HttpVerbs.Get)]
    public JsonResult GetEpicPropertyDetails(int id)
    {  
      var Epictemplist = epicRepository.Select().Where(x => x.Id.Equals(id)).SingleOrDefault();
      return Json(Epictemplist, JsonRequestBehavior.AllowGet);
    }
