    public ActionResult RealEstate(int id, string title)
    {
    ...prepare the model
    if (realEstateModel.Result.OfferState == OfferState.Deleted)
    {
        var alternativeSearchResult = PrepareAlternative(realEstateModel);
        return Gone410(alternativeSearchResult, context);                                        
    }
    else
       return View(realEstateModel);
    
    }
