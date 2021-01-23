    private static Dictionary<string /*name*/, Country> _countryDict =
      new List<Country>
        {
          new Country("Country1", new Rectangle(100, 200, 100, 100)),
          new Country("Country2", new Rectangle(200, 200, 100, 100))
        }.ToDictionary(c => c.Name);
