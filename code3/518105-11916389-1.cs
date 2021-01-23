    public ActionResult ShowReportForWeb()
    {
        var model = new MyViewModel { OutputFormatter = OutputFormatType.Web };
        return View("ShowReport", model);
    }
    
    public ActionResult ShowReportForPdf()
    {
        var model = new MyViewModel { OutputFormatter = OutputFormatType.PDF };
        return View("ShowReport", model);
    }
    
    public ActionResult ShowReport(MyViewModel model)
    {
        return View(model);
    }
