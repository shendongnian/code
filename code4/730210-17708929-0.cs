    [HttpGet]
    public ActionResult Details()
    {
        ViewBag.Title = "Cash Details";
        return View();            
    }
    [HttpGet]
    public async Task<PartialViewResult> _GetCashDetails()
    {
        CashClient srv = new CashClient();
        var response = await srv.GetCashDetails();
        return PartialView("_GetCashDetails", response);
    }
