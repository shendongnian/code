    public ActionResult EmailQuote(QuoteDataViewModel model) {
        if(ModelState.IsValid) {
            ....//save data that was entered?
        }
        return View(model);
    }
