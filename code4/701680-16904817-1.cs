    public ActionResult Index()
    {
        MyViewModel model = new MyViewModel();
        model.data = GetData();
        return View(model);
    }
    
    public JsonResult GetJson(DateTime startDate,DateTime endDate)
    {
        var result=GetData(startDate,endDate);
        return Json(result);
    }
    
    private IEnumerable<MyData> GetData(DateTime startDate=null,DateTime endDate=null)
    {
        return something;
    }
