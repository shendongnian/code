    enum Country
    {
        UnitedStates,
        Germany,
        Hungary
    }
    Dictionary<Country, string> CountryNames = new Dictionary<Country, string>
    {
        { Country.UnitedStates, "US" },
        { Country.Germany, "DE" }
        { Country.Hungary, "HU" }
    };
    static string ConvertCountry(Country country) 
    {
        string name;
        return (CountryNames.TryGetValue(country, out name))
            ? name : country.ToString();
    }
