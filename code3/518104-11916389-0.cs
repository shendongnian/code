    public ActionResult ShowReportForWeb()
    {
        var model = new MyViewModel { OutputType = OutputType.Web };
        return View("ShowReport", model);
    }
    
    public ActionResult ShowReportForPdf()
    {
        var model = new MyViewModel { OutputType = OutputType.PDF };
        return View("ShowReport", model);
    }
    
    public ActionResult ShowReport(MyViewModel model)
    {
        return View(model);
    }
