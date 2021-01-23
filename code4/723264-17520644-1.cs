    public ActionResult CountryView()
    {
        List<string> lstCountries = YourModel.GetCountryData();
        
        return View(lstCountries);
    }
