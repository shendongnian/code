    [HttpGet]
    public ActionResult MyReport()
    {
        ReportModel model = new ReportModel();
        // populate your model in order for all your inputs to show correctly (dropdowns data or whatever)
        return View("[pathToView]/ReportView.cshtml", model);
    }
    [HttpGet]
    public ActionResult ShowMyReport(ReportModel model)
    {
        if(ModelState.IsValid)
        {
            // inputs validated, show the report
            [get report data according to the input]
            return View(model);
        }
        // inputs didn't validate. Rerender view and show errors.
        return View("[pathToView]/ReportView.cshtml", model); // should be the same view
    }
