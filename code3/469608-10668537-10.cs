    public ActionResult Browse(string id)
    {
        var summaries = /* search using id as search term */
        return View(summaries);
    }
    
    [ActionName("StartBrowse")]
    public ActionResult Browse()
    {
        var summaries = /* default list when nothing entered */
        return View(summaries);
    }
