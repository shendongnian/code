    [HttpPost]
    public ActionResult Save(MyDataType saveData)
    {        
        //todo save logic here
        var mvcGridModel = GetGridData();
        var evo = new ExportDataOverviewViewObject
        {
            MvcGridModel = mvcGridModel ?? new MvcGrid(),
            SaveData = new MyDataType()
        };
        return PartialView("Overview", evo);
    }
