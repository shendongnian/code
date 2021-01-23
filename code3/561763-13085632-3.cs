    public JsonResult GetAllNames()
    {
       List<NamesModel> names = new List<NamesModel>();
       // 
       // code to fetch records
       //
       var result = Json(names);
       result .JsonRequestBehavior = JsonRequestBehavior.AllowGet;
       return result ;
    }
