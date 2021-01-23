    [HttpPost]
    public ActionResult SomeReport([FromBody] string input)
    {
        var model = new ReportBL();
        var report = model.Process(input);
        return View(report);
    }
