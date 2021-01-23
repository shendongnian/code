    [HttpPost]
    public ActionResult Top100_AllerTijden(FormCollection ACollection)
    {
        string sOverzicht= ACollection["Overzicht"].ToString();
        return RedirectToAction("NameOfTheActionWhichDisplaysTheWholePage", new { overzicht = sOverzicht })
    }
