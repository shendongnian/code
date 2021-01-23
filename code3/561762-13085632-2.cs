    [HttpPost]
    public JsonResult GetAllNames()
    {
       List<NamesModel> names = new List<NamesModel>();
       // 
       // code to fetch records
       //
       return Json(names);
    }
