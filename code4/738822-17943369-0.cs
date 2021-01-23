    var modelValue = property.GetValue(Model.FormModel);
    IEnumerable<SelectListItem> itemslist = 
             (from country in Service.GetCountries()
              select new SelectListItem {
              {
                value = country.Id.ToString(),
                text  = Localizator
                          .CountryNames[
                              (CountryCodes)Enum
                                             .Parse(typeof(CountryCodes),
                              country.Code)
                           ],
                selected = country.Id.ToString().Equals(modelValue)
               }).Distinct().ToList().OrderBy(l => l.text);
