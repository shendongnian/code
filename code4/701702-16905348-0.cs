    [HttpGet]
    [ChildActionOnly]
    public ActionResult RandomQuote()
    {
        var model = _services.GetRandomQuote();
    
        return PartialView("_QuoteOfTheMomentWidget", model);
    }
