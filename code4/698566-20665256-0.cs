    [HttpPost]
    public ActionResult PopulateReport(int groupId, int itemId)
    {
    string clickedReport;
    
    ...
    
    TempData["clickedReport"] = clickedReport;
    Session["clickedReport"] = clickedReport;
    
    return PartialView();
    
    }
    
    public ActionResult GridViewPartial()
    {
    
    // Now this other action method can get the clicked report assigned by the above action.
    var tmpData = TempData["clickedReport"];
    var sessionData = Session["clickedReport"];
    
    // Runs the report instance and returns an object that holds a DataTable and other info to the grid that's in the calling partial view.
    
    // Instantiate and populate GridConfig
    GridConfig gridConfig = new GridConfig();
    ...
    
    return PartialView("_GridViewPartial", gridConfig);
    
    }
