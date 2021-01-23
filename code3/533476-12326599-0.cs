    public JsonResult GetJSONYTD(int kpiID)
    {
        var graphData = departmentrepo.GetGraphData(kpiID);
        var ViewData = (from kpidata in graphData
    
                        select new DepartmentOverviewDetailsViewModel.GraphJSONViewModel
                        {
                            XData = kpidata.Year.Year1 + "-" + kpidata.Month.Real_Month_Int + "-01",
                            YData = graphData.Where(x=>x.Date<=kpidata.Date).Sum(x=>x.Value)
                        });
    
        var ChartData = ViewData.Select(x => new object[] { x.XData, x.YData }).ToArray();
    
        return Json(ChartData, JsonRequestBehavior.AllowGet);
    }
