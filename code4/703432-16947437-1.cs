    public static IEnumerable<SelectListItem> AllCountries
    {
        get
        {
           var countries = new List<SelectListItem>();
           foreach(var country in countryRegex.Keys)
           {
               countries.Add(SelectListItem() { Text = country, Value = country };
           }
           return countries;
        }
    }
