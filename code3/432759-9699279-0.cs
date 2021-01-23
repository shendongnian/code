    [HttpPost]
    public ActionResult ExcelReport(ReportModel model)
    {
        if(ModelState.IsValid)
        {
            ReportService reportCreator = new ReportService(); // or whatever class you use for that
            Task.Factory.StartNew( () => reportCreator.GenerateReport(model)); 
            //redirect somewhere or return a plain view with your message
            return View("ConfirmationMessage");
        }
        return View();
    }
