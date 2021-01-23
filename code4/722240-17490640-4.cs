    var countriesDictionary = countries.ToLookup(x => x.CountryCode, x => x);
    var dCountries = new List<Country>();
    foreach(var countryGroup in countriesDictionary)
    {
        foreach(var country in countryGroup)
        {
            Console.WriteLine(country.CountryName);
        }
        Console.WriteLine();
    }
