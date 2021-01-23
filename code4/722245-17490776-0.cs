     static class CountryExtension
        {
            public static void WriteCountriesGroupyCountryCode(this IEnumerable<Country> list)
            {
                int currentCountry=int.MinValue;
                list.OrderBy(c => c.CountryCode).ThenBy(c=>c.CountryName).ToList().ForEach(c =>
                {
                    if (currentCountry == int.MinValue)
                    {
                        currentCountry = c.CountryCode;
                    }
                    else if (currentCountry != c.CountryCode)
                    {
                        Console.WriteLine();
                        currentCountry = c.CountryCode;
                    }
                    Console.WriteLine(c.CountryName);
                });
            }
        }
