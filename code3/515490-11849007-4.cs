    [HttpPost]
    public ActionResult MyAction(MyViewModel model)
    {
        if (model.TermsEligibility)
        {
            ....
        }
    }
