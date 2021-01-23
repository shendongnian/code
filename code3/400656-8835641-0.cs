    @Html.ActionLink("Filter", "FilterDateRange", new { from = Model.FromDate, to = Model.ToDate }, null)
    public ActionResult FilterDateRange(DateTime from, DateTime to)
    {
        var fromDate = from;
        var toDate = to;
    
        //do stuffs
    
        return View("Index", statsPages);
    }
