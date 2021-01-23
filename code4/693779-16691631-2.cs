    public static IEnumerable<Country> GetAllCountries()
    {
        using (var context = new ReportEntities())
        {
            //Note, this LINQ query can also return an IQueryable.  This is useful
            //if you're querying a database because you'll be doing more logic in SQL
            //and transferring less data from your database to memory on your C# machine
            IEnumerable<Country> countries = 
                     from c in context.Countries
                     group c by c.CountryName into countriesGroupedByName
                     select countriesGroupedByName.First();
            return countries;
        }
    }
