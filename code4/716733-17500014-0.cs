    private static IDictionary<string, Country> _countries;
        
    public IDictionary<string, Country> Countries
    {
        get
        {
            if (_countries == null)
            {
                var culture = System.Globalization.CultureInfo.CurrentCulture;
                var name = culture.Name;
                if (name == "en-us")
                {
                    // load
                }
                else
                {
                    // load
                }
            }
            return _countries;
        }
    }
