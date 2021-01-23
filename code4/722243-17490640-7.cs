    countriesDictionary.ToList().ForEach
    (
        pair =>
        {
            pair.Value.ForEach(country => Console.WriteLine(country.CountryName));
            Console.WriteLine();
        }
    );
