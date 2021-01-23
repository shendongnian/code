    public ActionResult EMailQuote() {
        ...
        var model = new QuoteDataViewModel();
        var quoteData = new QuoteData();
        ... 
        model.Chapter7 = Chapter7;
        return View(model);
    }
