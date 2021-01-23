    public ActionResult Index(SummaryFilterInfo summaryFilterInfo)
        {
            ...
            var filtered = all
                           .Where(e => summaryFilterInfo.States.Contains(e.State)).ToList()
        }
