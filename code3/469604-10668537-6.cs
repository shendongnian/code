    public ActionResult Browse(string id)
    {
        var summaries = /* search using id as search term */
        return View(summaries);
    }
    
    public ActionResult StartBrowse()
    {
        var summaries = /* default list when nothing entered */
        return View(summaries);
    }
