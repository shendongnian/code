    public static IEnumerable<Country> GetAllCountries()
    {
    
        using (var context = new ReportEntities())
        {
            IEnumerable<Country> countries = 
                     from c in context.Countries
                     group c by c.CountryName into countriesGroupedByName
                     select countriesGroupedByName.First();
            return countries;
        }
    }
