    [HttpPost]
    public ActionResult GetData(string zipcode)
    {
     //return DateTime.Now.ToShortDateString();
            srvc.BudgetBlindsCommercialSolutions tmp = new srvc.BudgetBlindsCommercialSolutions();
            string code = tmp.GetFETerrByZip(zipcode);
            return Json(new {code= code});
    }
