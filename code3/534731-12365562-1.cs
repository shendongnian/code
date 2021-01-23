    [HttpPost]
    public JsonResult DateManipulation(string date)
    {
        DateTime date = DateTime.ParseExact(date, "d|M|yyyy", CultureInfo.InvariantCulture);
    
        var data = //process some other manipulation with data      
        return Json(data);
    }
