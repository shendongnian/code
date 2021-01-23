    public ViewResult CheckCountryName([Bind(Prefix="Country")]Country oCountry)
    {
         //some code
         return View(oCountry);
    }
