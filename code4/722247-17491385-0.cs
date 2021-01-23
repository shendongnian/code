        List<string> countryNames = countriesDictionary.SelectMany(
            pair=>pair.Value.Where(
                country=>country.CountryCode == pair.Key
            ).Select(x=>x.CountryName)).ToList();
        foreach (var name in countryNames)
            Console.WriteLine(name);
