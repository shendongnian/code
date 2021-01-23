    [HttpPost]
    public ActionResult StatesByCountry(int countryId)
    {
        // Filter the states by country. For example:
        var states = (from s in dbContext.States
                      where s.CountryId == countryId
                      select new
                      {
                          id = s.Id,
                          state = s.Name
                      }).ToArray();
        return Json(states);
    }
